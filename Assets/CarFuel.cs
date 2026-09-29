using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarFuel : MonoBehaviour
{
    //slider
    
    //label

    //effect

    public Slider fuelSlider;
    public Text lowFuelLabel;
    public ParticleSystem lowFuel;
    public ParticleSystem getFuel;

    private float fuel;

    public CarHealth health;

    public AudioEffects audio;

    public QuestsController quests;

    public Text questProgressShow;

    private int singleRunFuels;

    void Start(){
        fuel = 100;

        singleRunFuels = 0;
    }


    void Update(){
        if(fuel<=0 && CarMove.speed!=0){
            audio.playFuelLow();
            health.receiveDamage(100);
        }

        if(fuel>0 && CarMove.speed!=0){
            fuel-=0.1f;
            fuelSlider.value=fuel;
        }

        if(fuel<15){
            //audio.playAlert();

            lowFuelLabel.gameObject.SetActive(true);
            lowFuel.Play();
        }
        else{
            
            lowFuelLabel.gameObject.SetActive(false);
            lowFuel.Stop();
        }
    }



    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Fuel")
        {
            Destroy(other.gameObject);
            getFuel.Play();
            fuel = 100;

            audio.playFuelGet();

            singleRunFuels++;

            HandleQuestsProgress();
        }
    }
    
    void HandleQuestsProgress()
    {
        if (quests.slot.slot.activeSelf)
        {
            if (!quests.IsQuestCompleted("3_gas_cans") && quests.IsCurrent("3_gas_cans"))
            {
                questProgressShow.text = "Progress: " + singleRunFuels.ToString() + "/3";
            }

            if (!quests.IsQuestCompleted("6_gas_cans") && quests.IsCurrent("6_gas_cans"))
            {
                questProgressShow.text = "Progress: " + singleRunFuels.ToString() + "/6";
            }
        }

        if (singleRunFuels >= 3)
        {
            if (!quests.IsQuestCompleted("3_gas_cans") && quests.IsCurrent("3_gas_cans"))
            {
                questProgressShow.text = "";

                quests.CompleteQuest("3_gas_cans");
            }
        }

        if (singleRunFuels >= 6)
        {
            if (!quests.IsQuestCompleted("6_gas_cans") && quests.IsCurrent("6_gas_cans"))
            {
                questProgressShow.text = "";

                quests.CompleteQuest("6_gas_cans");
            }
        }
    }


}
