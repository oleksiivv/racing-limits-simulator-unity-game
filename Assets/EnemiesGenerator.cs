using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesGenerator : MonoBehaviour
{
    public GameObject[] enemiesForward;
    public GameObject[] enemiesBack;

    public float delayF=8.5f,delayB=8.5f;


    void Start(){
        Invoke(nameof(startGame),3f);
    }

    void startGame(){
        StartCoroutine(instBackEnemies());
        StartCoroutine(instForwardEnemies());
    }

    void Update(){
        
    }



    IEnumerator instForwardEnemies(){
        while(CarMove.speed!=0){
            int n=Random.Range(0,enemiesForward.Length);

            Instantiate(enemiesForward[n],enemiesForward[n].transform.position,enemiesForward[n].transform.rotation);

            yield return new WaitForSeconds(Random.Range(delayF*0.5f,delayF));

            if(delayF>2)delayF*=0.9995f;
        }
    }


    IEnumerator instBackEnemies(){
        while(CarMove.speed!=0){
            yield return new WaitForSeconds(Random.Range(delayB*0.8f,delayB*1.2f));

            int n=Random.Range(0,enemiesBack.Length);
            Instantiate(enemiesBack[n],enemiesBack[n].transform.position,enemiesBack[n].transform.rotation);
            if(delayB>2)delayB*=0.9995f;
        }
    }
}
