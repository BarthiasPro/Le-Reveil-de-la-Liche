using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    public static event System.Action<int> OnEnemyDied = delegate { };
    public static event System.Action<int> OnItemFound = delegate { };
    public static event System.Action<int> OnPnjTalked = delegate { };
    public static event System.Action<Quest> OnQuestProgressChanged = delegate { };
    public static event System.Action<Quest> OnQuestCompleted = delegate { };

    public static void EnemyDied(int enemyID)
    {
        OnEnemyDied(enemyID);
    }

    public static void ItemFound(int itemID)
    {
        OnItemFound(itemID);
    }

    public static void PnjTalked(int pnjID)
    {
        OnPnjTalked(pnjID);
    }

    public static void QuestProgressChanged(Quest quest)
    {
        OnQuestProgressChanged(quest);
        // on appelle UpdateProgress dans QuestUIItem
        // on appelle UpdateQuestData dans QuestDatabase

    }

    public static void QuestCompleted(Quest quest)
    {
        OnQuestCompleted(quest);
        // on appelle Completed dans QuestGiver
        // on appelle QuestCompleted dans QuestUIItem

    }

}
