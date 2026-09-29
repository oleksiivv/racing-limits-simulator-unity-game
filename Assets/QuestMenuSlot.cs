using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestMenuSlot : MonoBehaviour
{
    public GameObject slot;

    public Animation animation;

    public Image icon;
    public Text name;
    public Text description;
    public Text status;

    public void ShowQuest(Quest quest, Color32 iconColor, string statusText, Color32 textColor)
    {
        icon.sprite = quest.icon;
        name.text = quest.name;
        description.text = quest.description;

        icon.color = new Color32(255, 255, 255, iconColor.a);

        status.text = statusText;

        var statusTextColor = new Color32(iconColor.r, iconColor.g, iconColor.b, 255);

        status.color = statusTextColor;
        name.color = textColor;
        description.color = textColor;
    }
}
