using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemy : MonoBehaviour
{
    public float speed=1;

    private GameObject ground;

    private Vector3 startPos;

    void Start(){

        startPos=transform.position;
        this.init();
        //Invoke(nameof(clean),10f);

        speed/=35;

    }
    public virtual void init(){
        return;
    }

    void Update()
    {
        if(Time.timeScale!=0){
            if(speed!=0)transform.Translate(Vector3.forward*speed*PlayerPrefs.GetFloat("quality",2.5f));
            else transform.position=Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,transform.position.y,-14),0.01f*CarMove.speed*Time.timeScale*PlayerPrefs.GetFloat("quality",2.5f));
        }
    }

    void clean(){
        Destroy(gameObject);
    }

    public void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Enemy"){
            if(Mathf.Abs(other.gameObject.transform.position.z - startPos.z)<0.1f){
                Destroy(gameObject);
            }
            /*int deg=Random.Range(-90,90);
            if(Mathf.Abs(deg)<20) deg=30*deg<0?1:-1;
            transform.Rotate(0,deg,0);*/
            speed=0;
            //gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
    public void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Enemy"){
            speed=1;

            //Debug.Log("Collision");
        }
    }
}
