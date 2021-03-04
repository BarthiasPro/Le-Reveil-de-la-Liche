using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PNJ : MonoBehaviour
{

    public Interactable inter;
    public PlayerUI ui;
    public Player player;
    public QuestDatabase database;
    public QuestGiver questGiver;



    public string pnjName;
    public int pnjID;
    public string dialogText_0;



    private void Awake()
    {
        ui = FindObjectOfType<PlayerUI>();
        player = FindObjectOfType<Player>();
        database = FindObjectOfType<QuestDatabase>();
        dialogText_0 = "Bonjour je suis un PNJ";
    }

    public virtual void Speak()
    {
        Tell(dialogText_0);
        ui.DisableInteractText();       
    }


    public void Tell(string line)
    {
        ui.SetDialog(this.transform.position, pnjName + ": " + line);
    }


    public void GiveQuest(string questName)
    {
        if (questGiver != null)
        {
            questGiver.questName = questName;
            questGiver.GiveQuest();
        }
    }

}
