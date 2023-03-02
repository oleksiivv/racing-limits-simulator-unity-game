using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarScore : MonoBehaviour
{
    public Text score;
    public Text hi;
    public Text newHiLabel;

    private float scoreVal, distToShow;
    private bool hiLabelShowed;


    void Start(){
        hi.text=PlayerPrefs.GetInt("hi").ToString();
        scoreVal=0f;

        hiLabelShowed=PlayerPrefs.GetInt("hi",-1)==-1;
    }


    void Update(){
        

        if((int)scoreVal>PlayerPrefs.GetInt("hi")){
            if(PlayerPrefs.GetInt("hi")!=0 && !hiLabelShowed && Mathf.Abs(PlayerPrefs.GetInt("hi")-(int)scoreVal)>0){
                hiLabelShowed=true;
                newHiLabel.gameObject.SetActive(true);
                Invoke(nameof(offNewHiLabel),3f);
            }

            PlayerPrefs.SetInt("hi",(int)scoreVal);
            hi.text=PlayerPrefs.GetInt("hi").ToString();

        }

        if(Time.timeScale!=0){
            scoreVal+=1*CarMove.speed;
            if(scoreVal>1000){
                distToShow = scoreVal / 1000f;

                distToShow = (float)Mathf.Round(distToShow * 10f) / 10f;

                score.text = distToShow.ToString()+"km";
            }
            else{
                score.text = ((int)scoreVal).ToString()+"m";
            }
        }

        //score.text=((int)scoreVal).ToString();
    }


    void offNewHiLabel(){
        newHiLabel.gameObject.SetActive(false);
    }




}
