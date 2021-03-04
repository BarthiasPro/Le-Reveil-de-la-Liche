using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestDatabase : MonoBehaviour
{
    public Dictionary<string, int[]> Quests = new Dictionary<string, int[]>();

    private void Awake()
    {
        EventController.OnQuestProgressChanged += UpdateQuestData;
    }

    public bool Completed(string questName)
    {
        if(Quests.ContainsKey(questName))
        {
            //si la quete a été accepté on peut savoir si elle a été terminé
            if (System.Convert.ToBoolean(Quests[questName][0]))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        return false;

    }

    public void AddQuest(Quest quest)
    {
        if(Quests.ContainsKey(quest.questName) == false)
        {
            Quests.Add(quest.questName, new int[] { 0, 0 });
        }
        else
        {
            if(this.Completed(quest.questName) == true)
            {
                Debug.LogError("La quête a déja été accepté et accompli");
            }
            else
            {
                Debug.LogError("La quête a déja été accepté mais pas encore accompli");
            }
        }
    }

    public void UpdateQuestData(Quest quest)
    {
        Quests[quest.questName] = new int[] { System.Convert.ToInt32(quest.completed), quest.goal.countCurrent};
        Debug.Log("Data updated for: " + quest.questName);
    }
}
