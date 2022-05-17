using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarHealth : MonoBehaviour
{
    public CarEffects vfx;
    public CarUI ui;

    private int health=100;

    void Start(){
        health=100;
    }

    public void receiveDamage(int damage){
        health-=damage;

        if(health<=0){
            CarMove.speed=0;
            Invoke(nameof(showDeathPanel),1.4f);
            vfx.playDeath();
        }
        else{
            vfx.playDamage();
        }
    }


    private void showDeathPanel(){
        ui.showDeathPanel();
    }
}
