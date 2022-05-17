using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarEnemy : MonoBehaviour
{
    public float speed=1;
    void Start(){
        this.init();
        //Invoke(nameof(clean),10f);

        

    }
    public virtual void init(){
        return;
    }

    void Update()
    {
        if(Time.timeScale!=0)transform.Translate(Vector3.forward*speed/35*PlayerPrefs.GetFloat("quality",2.5f));
    }

    void clean(){
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other){
        if(other.gameObject.tag=="Enemy"){
            int deg=Random.Range(-90,90);
            if(Mathf.Abs(deg)<20) deg=30*deg<0?1:-1;
            transform.Rotate(0,deg,0);
        }
        else if(other.gameObject.tag=="Clean"){
            clean();
        }
    }
    void OnTriggerExit(Collider other){
        if(other.gameObject.tag=="Enemy"){
            speed=1;

            Debug.Log("Collision");
        }
    }
}
