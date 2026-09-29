using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarCollisions : MonoBehaviour
{
    public CarHealth health;
    public Animator animator;

    public Text coins;

    public AudioEffects audio;

    public QuestsController quests;

    public Text questProgressShow;

    private int singleRunCoins = 0;

    void Start(){
        coins.text = PlayerPrefs.GetInt("coins").ToString();

        singleRunCoins = 0;
    }




    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Enemy"){
            CarMove.speed=0.1f;
            health.receiveDamage(10);

            Debug.Log("Collision");
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            if (CarMove.speed != 0) health.receiveDamage(100);

            other.gameObject.GetComponent<CarEnemy>().speed = 0;
            Destroy(other.gameObject.GetComponent<CarEnemy>());

            audio.playDamageGet();
        }
        else if (other.gameObject.tag == "Coin")
        {
            PlayerPrefs.SetInt("coins", PlayerPrefs.GetInt("coins") + 1);
            coins.text = PlayerPrefs.GetInt("coins").ToString();

            Destroy(other.gameObject);
            health.vfx.playGetItem();

            audio.playCoinGet();

            singleRunCoins++;

            HandleQuestsProgress();
        }
    }
    
    void HandleQuestsProgress()
    {
        if (quests.slot.slot.activeSelf)
        {
            if (!quests.IsQuestCompleted("20_coins") && quests.IsCurrent("20_coins"))
            {
                questProgressShow.text = "Progress: " + singleRunCoins.ToString() + "/20";
            }

            if (!quests.IsQuestCompleted("40_coins") && quests.IsCurrent("40_coins"))
            {
                questProgressShow.text = "Progress: " + singleRunCoins.ToString() + "/40";
            }

            if (!quests.IsQuestCompleted("50_coins_ambulance") && quests.IsCurrent("50_coins_ambulance"))
            {
                if (PlayerPrefs.GetInt("current", 0) == 6)
                {
                    questProgressShow.text = "Progress: " + singleRunCoins.ToString() + "/50";
                } else
                {
                    questProgressShow.text = "";
                }
            }
        }

        if (singleRunCoins >= 20)
        {
            if (!quests.IsQuestCompleted("20_coins") && quests.IsCurrent("20_coins"))
            {
                questProgressShow.text = "";

                quests.CompleteQuest("20_coins");
            }
        }

        if (singleRunCoins >= 40)
        {
            if (!quests.IsQuestCompleted("40_coins") && quests.IsCurrent("40_coins"))
            {
                questProgressShow.text = "";

                quests.CompleteQuest("40_coins");
            }
        }

        if (singleRunCoins >= 50 && PlayerPrefs.GetInt("current", 0) == 6)
        {
            if (!quests.IsQuestCompleted("50_coins_ambulance") && quests.IsCurrent("50_coins_ambulance"))
            {
                questProgressShow.text = "";

                quests.CompleteQuest("50_coins_ambulance");
            }
        }
    }

}
