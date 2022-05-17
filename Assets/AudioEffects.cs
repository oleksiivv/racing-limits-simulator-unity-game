using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioEffects : MonoBehaviour
{
    public AudioSource source;
    public AudioClip coin,fuel,damage,alert,fuelLow;

    public void playCoinGet(){
        source.enabled=false;
        source.clip=coin;
        source.enabled=true;
        source.Play();
    }

    public void playFuelGet(){
        source.enabled=false;
        source.clip=fuel;
        source.enabled=true;
        source.Play();
    }

    public void playDamageGet(){
        source.enabled=false;
        source.clip=damage;
        source.enabled=true;
        source.Play();
    }

    public void playAlert(){
        source.enabled=false;
        source.clip=alert;
        source.enabled=true;
        source.Play();
    }

    public void playFuelLow(){
        source.enabled=false;
        source.clip=fuelLow;
        source.enabled=true;
        source.Play();
    }

}
