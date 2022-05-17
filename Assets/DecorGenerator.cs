using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecorGenerator : MonoBehaviour
{
    public GameObject[] decor;

    float delay=3f;
    void Start(){
        StartCoroutine(instDecor());
    }

    void Update(){
        
    }



    IEnumerator instDecor(){
        while(CarMove.speed!=0){
            int n=Random.Range(0,decor.Length);

            Instantiate(decor[n],decor[n].transform.position,decor[n].transform.rotation);

            yield return new WaitForSeconds(Random.Range(delay*0.5f,delay));

            if(delay>2)delay*=0.9995f;
        }
    }


}
