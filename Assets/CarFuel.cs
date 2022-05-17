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

    void Start(){
        fuel=100;
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



    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Fuel"){
            Destroy(other.gameObject);
            getFuel.Play();
            fuel=100;

            audio.playFuelGet();
        }
    }


}
