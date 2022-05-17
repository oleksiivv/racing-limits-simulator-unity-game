using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.position=new Vector3(Random.Range(-0.5f,0.5f),transform.position.y,-7);
    }

    void Update(){
        transform.position=Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,transform.position.y,-14),0.01f*CarMove.speed*Time.timeScale*PlayerPrefs.GetFloat("quality",2.5f));
    }

     void OnTriggerEnter(Collider other){
         if(other.gameObject.tag=="Player"){
             //other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*100);
             gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*250);
             gameObject.GetComponent<Rigidbody>().AddForce(Vector3.back*50);
             
         }
     }
}
