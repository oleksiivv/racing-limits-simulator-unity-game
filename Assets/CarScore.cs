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

    public QuestsController quests;

    public Text questProgressShow;

    void Start(){
        hi.text=PlayerPrefs.GetInt("hi").ToString();
        scoreVal=0f;

        hiLabelShowed = PlayerPrefs.GetInt("hi", -1) == -1;
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
            scoreVal += 1 * CarMove.speed;
            PlayerPrefs.SetInt("total_distance", PlayerPrefs.GetInt("total_distance", 0) + (int)(1 * CarMove.speed));

            if (scoreVal > 1000)
            {
                distToShow = scoreVal / 1000f;

                distToShow = (float)Mathf.Round(distToShow * 10f) / 10f;

                score.text = distToShow.ToString() + "km";
            }
            else
            {
                score.text = ((int)scoreVal).ToString() + "m";
            }

            HandleQuestsProgress();
        }

        //score.text=((int)scoreVal).ToString();
    }


    void offNewHiLabel()
    {
        newHiLabel.gameObject.SetActive(false);
    }



    void HandleQuestsProgress()
    {
        if (quests.slot.slot.activeSelf)
        {
            if (!quests.IsQuestCompleted("3kms") && quests.IsCurrent("3kms"))
            {
                questProgressShow.text = "Progress: " + distToShow.ToString() + "/3";
            }

            if (!quests.IsQuestCompleted("5kms_police") && quests.IsCurrent("5kms_police"))
            {
                if (PlayerPrefs.GetInt("current", 0) == 5)
                {
                    questProgressShow.text = "Progress: " + distToShow.ToString() + "/5";
                }
                else
                {
                    questProgressShow.text = "";
                }
            }
            
            if (!quests.IsQuestCompleted("300_kms") && quests.IsCurrent("300_kms"))
            {
                var toShow = PlayerPrefs.GetInt("total_distance", 0) / 1000f;

                toShow = (float)Mathf.Round(toShow * 10f) / 10f; 

                questProgressShow.text = "Progress: " + ((int)toShow).ToString() + "/300";
            }
        }

        if (scoreVal >= 3000)
        {
            if (!quests.IsQuestCompleted("3kms") && quests.IsCurrent("3kms"))
            {
                questProgressShow.text = "";

                quests.CompleteQuest("3kms");
            }

            if (!quests.IsQuestCompleted("5kms_police") && PlayerPrefs.GetInt("current", 0) == 5 && quests.IsCurrent("5kms_police"))
            {
                questProgressShow.text = "";

                quests.CompleteQuest("5kms_police");
            }

            if (!quests.IsQuestCompleted("300_kms") && quests.IsCurrent("300_kms"))
            {
                questProgressShow.text = "";

                quests.CompleteQuest("300_kms");
            }
        }
    }

}
