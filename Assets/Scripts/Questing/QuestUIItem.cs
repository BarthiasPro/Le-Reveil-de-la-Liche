using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class QuestUIItem : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI questName, questProgress;

    private Quest quest;

    private void Start()
    {
        EventController.OnQuestCompleted += QuestCompleted;
        EventController.OnQuestProgressChanged += UpdateProgress;
    }

    public void Setup(Quest questToSetup)
    {
        quest = questToSetup;
        questName.text = questToSetup.description;
        questProgress.text = questToSetup.goal.countCurrent + "/" + questToSetup.goal.countNeeded;
    }

    public void UpdateProgress(Quest quest)
    {
        if(this.quest == quest)
        {
            questProgress.text = quest.goal.countCurrent + "/" + quest.goal.countNeeded;
        }
    }

    public void QuestCompleted(Quest quest)
    {
        if(this.quest == quest)
        {
            Destroy(this.gameObject, 1f);
        }
    }


}
