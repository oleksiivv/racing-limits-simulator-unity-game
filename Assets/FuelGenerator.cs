using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelGenerator : MonoBehaviour
{
    public GameObject[] fuel;

    float delay=13f;
    void Start(){
        StartCoroutine(instFuel());
    }

    void Update(){
        
    }



    IEnumerator instFuel(){
        while(CarMove.speed!=0){

            yield return new WaitForSeconds(Random.Range(delay*0.8f,delay*1.2f));


            int n=Random.Range(0,fuel.Length);

            Instantiate(fuel[n],fuel[n].transform.position,fuel[n].transform.rotation);

            

        }
    }
}
