using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestController : MonoBehaviour
{
    public List<Quest> assignedQuests = new List<Quest>();

    [SerializeField]
    private QuestUIItem questUIItem;
    [SerializeField]
    private Transform questUIParent;

    private QuestDatabase questDatabase;

    private void Start()
    {
        questDatabase = GetComponent<QuestDatabase>();
    }



    public Quest AssignQuest(string questName)
    {   
        foreach (Quest q in assignedQuests)
        {
            if ( q.questName == questName)
            {
                Debug.LogWarning("La quete est déja assigné");
                return null;
            }            
        }
        // trouver la quete a partir de son nom
        Quest questToAdd = (Quest)gameObject.AddComponent(System.Type.GetType(questName));
        assignedQuests.Add(questToAdd);
        questDatabase.AddQuest(questToAdd);

        //on ajoute un slot de quete dans le menu déroulant
        QuestUIItem questUI = Instantiate(questUIItem, questUIParent);
        //on écris les informations de la quete dans ce slot
        questUI.Setup(questToAdd);
        return questToAdd;
       
        
    }
    
}
