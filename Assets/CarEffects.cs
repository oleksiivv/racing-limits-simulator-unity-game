using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEffects : MonoBehaviour
{
    public ParticleSystem[] runEffects;
    public ParticleSystem[] damageEffects;

    public ParticleSystem[] deathEffects;

    public ParticleSystem coinGet;


    public void playDamage(){
        foreach(var effect in runEffects)effect.Stop();
        foreach(var effect in deathEffects)effect.Stop();

        foreach(var effect in damageEffects)effect.Play();


        //Invoke(nameof(resumeRun),1f);
    }

    public void playRun(){
        foreach(var effect in deathEffects)effect.Stop();
        foreach(var effect in damageEffects)effect.Stop();

        foreach(var effect in runEffects)effect.Play();
    }

    public void playDeath(){
        foreach(var effect in runEffects)effect.Stop();
        foreach(var effect in damageEffects)effect.Stop();
        //foreach(var effect in deathEffects)effect.Stop();

        foreach(var effect in deathEffects)effect.Play();


        //Invoke(nameof(resumeRun),1f);
    }

    public void playGetItem(){
        coinGet.Play();
    }

    public void resumeRun(){
        playRun();
    }
}
