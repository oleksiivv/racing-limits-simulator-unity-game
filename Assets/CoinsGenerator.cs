using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsGenerator : MonoBehaviour
{
    public GameObject[] coins;

    float delay=5f;
    void Start(){
        StartCoroutine(instCoins());
    }

    void Update(){
        
    }



    IEnumerator instCoins(){
        while(CarMove.speed!=0){

            yield return new WaitForSeconds(Random.Range(delay*0.8f,delay*1.2f));


            int n=Random.Range(0,coins.Length);

            Instantiate(coins[n],coins[n].transform.position,coins[n].transform.rotation);

            

        }
    }
}
