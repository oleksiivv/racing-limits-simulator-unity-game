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

    void Start(){
        coins.text=PlayerPrefs.GetInt("coins").ToString();
    }




    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag=="Enemy"){
            CarMove.speed=0.1f;
            health.receiveDamage(10);

            Debug.Log("Collision");
        }
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Enemy"){
            if(CarMove.speed!=0)health.receiveDamage(100);

            other.gameObject.GetComponent<CarEnemy>().speed=0;
            Destroy(other.gameObject.GetComponent<CarEnemy>());

            audio.playDamageGet();
        }
        else if(other.gameObject.tag=="Coin"){
            PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+1);
            coins.text=PlayerPrefs.GetInt("coins").ToString();

            Destroy(other.gameObject);
            health.vfx.playGetItem();

            audio.playCoinGet();
        }
    }

}
