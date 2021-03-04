using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestGiver : MonoBehaviour
{
    public string questName;

    private QuestController questController;
    private Quest quest;
    public GameObject questIndicator;



    // Start is called before the first frame update
    void Start()
    {
        questController = FindObjectOfType<QuestController>();

        EventController.OnQuestCompleted += Completed;
    }

    public void GiveQuest()
    {
        // on ajoute la quete dans la liste des quetes actives, dans la database et dans l'UI
        // et on récupère un pointeur sur cette quête (pour pouvoir la compléter plus tard)
        quest = questController.AssignQuest(questName);
        questIndicator.SetActive(false);
    }

    public void Completed(Quest quest)
    {
        if(this.quest != null && quest == this.quest)
        {
            //GetComponent<UnityEngine.UI.Button>().interactable = false;
            // c'est surement ici qu'il faudrait passer a la quete d'après.
        }
    }

}
