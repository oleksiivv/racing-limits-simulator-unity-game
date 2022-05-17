using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Road : MonoBehaviour
{
    public Vector3 instPos;
    public Vector3 startPos;

    void Update(){
        transform.position=Vector3.MoveTowards(transform.position,new Vector3(transform.position.x,transform.position.y,instPos.z-1),0.01f*CarMove.speed*Time.timeScale*PlayerPrefs.GetFloat("quality",2.5f));

        if((int)instPos.z==(int)transform.position.z){
            cleanAllChilds();
            transform.position+=new Vector3(0,0,12);
            //transform.position=new Vector3(transform.position.x,transform.position.y,startPos.z);
        }
    }

    void cleanAllChilds(){
        for(int i=2;i<transform.childCount;i++){
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
