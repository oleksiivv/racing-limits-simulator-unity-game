using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    void Start()
    {
        transform.position=new Vector3(Random.Range(-0.5f,0.5f),transform.position.y,-7);
    }

    void Update(){
        transform.position=Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,transform.position.y,-14),0.01f*CarMove.speed*Time.timeScale*PlayerPrefs.GetFloat("quality",2.5f));
    }

     void OnTriggerEnter(Collider other){
         if(other.gameObject.tag=="Enemy"){
             //Destroy(gameObject);

         }
     }
}
