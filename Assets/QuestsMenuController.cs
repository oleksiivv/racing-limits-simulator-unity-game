using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestsMenuController : MonoBehaviour
{
    public List<Quest> quests;
    public List<QuestMenuSlot> questSlots;

    void Start()
    {
        Init();
    }

    public void Init()
    {
        var currentQuest = PlayerPrefs.GetInt("current_quest_id", 0);
        int amount = questSlots.Count;
        int startFrom = 1;

        if (currentQuest >= quests.Count)
        {
            startFrom = 0;
        }
        else
        {
            questSlots[0].gameObject.SetActive(true);
            questSlots[0].ShowQuest(quests[currentQuest], new Color32(150, 255, 140, 255), "Current", new Color32(150, 255, 140, 255));
        }

        for (int i = startFrom; i < amount; i++)
        {
            if (i <= currentQuest)
            {
                questSlots[i].gameObject.SetActive(true);
                questSlots[i].ShowQuest(quests[i - startFrom], new Color32(150, 255, 140, 200), "Completed", new Color32(150, 255, 140, 200));
            }
            else if (i > currentQuest)
            {
                questSlots[i].gameObject.SetActive(true);
                questSlots[i].ShowQuest(quests[i - startFrom + 1], new Color32(255, 255, 255, 45), "Unavailable yet", new Color32(150, 255, 140, 45));
            }
        }
    }
}
