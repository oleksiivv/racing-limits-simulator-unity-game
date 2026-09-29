using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsController : MonoBehaviour
{
    public QuestSlot slot;
    public List<Quest> quests;

    private int currentQuestId;
    public int totalQuestsAmount;

    public GameObject questCompletedAlert;

    // public SlimeSoundEffects sound;

    private int questsInCurrentRun=0;

    // public CoinsController coins;

    public Text questsProgress, coins;

    void Start()
    {
        questsProgress.gameObject.SetActive(false);

        currentQuestId = PlayerPrefs.GetInt("current_quest_id", 0);

        if (currentQuestId <= totalQuestsAmount)
        {
            Invoke(nameof(ShowQuest), 1.5f);
        }

        // Invoke(nameof(DebugOnlyCompleteCurrentQuest), 10);
    }

    public void ShowQuest(){
        if(currentQuestId <= totalQuestsAmount && currentQuestId<quests.Count && slot){
            slot.SetQuest(quests[currentQuestId]);

            // sound.PlayNewQuestAVailable();

            questsProgress.gameObject.SetActive(true);
        }
    }

    void DebugOnlyCompleteCurrentQuest()
    {
        CompleteCurrentQuest();
    }

    public void CompleteCurrentQuest(bool isBackgrounQuest = false)
    {
        // coins.updateCoinsValue(100);

        currentQuestId++;
        PlayerPrefs.SetInt("current_quest_id", currentQuestId);

        Debug.Log("Quest: " + currentQuestId.ToString());

        questsInCurrentRun++;

        if (isBackgrounQuest)
        {
            return;
        }

        if (IsInvoking(nameof(HideQuestPanel)))
        {
            return;
        }

        questCompletedAlert.gameObject.SetActive(true);

        Invoke(nameof(HideQuestPanel), 3f);

        Invoke(nameof(HideQuestCompletedAlert), 3f);

        Invoke(nameof(ShowQuest), 5f);

        // sound.PlayQuesstCompleted();

        PlayerPrefs.SetInt("coins",PlayerPrefs.GetInt("coins")+50);
        coins.text=PlayerPrefs.GetInt("coins").ToString();
    }

    void HideQuestPanel(){
        slot.Hide();

        questsProgress.gameObject.SetActive(false);
    }

    void HideQuestCompletedAlert(){
        questCompletedAlert.GetComponent<Animation>().Play("HideQuestSlot");
        Invoke(nameof(SetQuestCompletedAlertActiveFalse), 1.2f);
    }

    void SetQuestCompletedAlertActiveFalse(){
        questCompletedAlert.SetActive(false);
    }

    public void CompleteQuest(string code, bool isBackgrounQuest=false){
        if(PlayerPrefs.GetInt("quest_completed_"+code, 0) == 1){
            return;
        }

        bool canBeCompleted=false;
        int questId=0;

        foreach(var quest in quests){
            if(quest.code == code && questId == currentQuestId){
                canBeCompleted=true;
            }

            questId++;
        }

        if(canBeCompleted){
            Debug.Log("can be completed - "+code);
            CompleteCurrentQuest(isBackgrounQuest);
            PlayerPrefs.SetInt("quest_completed_"+code, 1);
        }
    }

    public bool IsQuestCompleted(string code)
    {
        return PlayerPrefs.GetInt("quest_completed_" + code, 0) == 1;
    }

    public bool IsCurrent(string code)
    {
        var indexOfCurrent = PlayerPrefs.GetInt("current_quest_id", 0);

        if(indexOfCurrent >= quests.Count)
        {
            return false;
        }

        if (quests[indexOfCurrent].code == code)
        {
            return true;
        }

        return false;
    }

    public int GetCompletedQuestsAmount()
    {
        return currentQuestId;
    }

    public int GetCompletedQuestsInCurrentRunAmount(){
        return questsInCurrentRun;
    }
}
