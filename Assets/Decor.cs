using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Decor : MonoBehaviour
{
    private Rigidbody rigidbody;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = gameObject.GetComponent<Rigidbody>();
        transform.position=new Vector3(Random.Range(-1.25f,1.25f),transform.position.y,-7);
    }

    void Update(){
        //rigidbody.velocity = -Vector3.forward*0.5f*CarMove.speed*Time.timeScale*PlayerPrefs.GetFloat("quality",2.5f);
        transform.position=Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,transform.position.y,-14),0.01f*CarMove.speed*Time.timeScale*PlayerPrefs.GetFloat("quality",2.5f));
    }

    bool wasAtRoad = false;

     void OnCollisionEnter(Collision other){
         if(other.gameObject.tag != "Ground"){
             transform.parent = null;
             //other.gameObject.GetComponent<Rigidbody>().AddForce(Vector3.up*100);
             rigidbody.AddForce(Vector3.up*550);
             rigidbody.AddForce(Vector3.back*130);
             
             Debug.Log("Decor Collision");
         }
         else if(!wasAtRoad){
             wasAtRoad=true;
             //transform.parent = other.gameObject.transform;
         }
     }
}
