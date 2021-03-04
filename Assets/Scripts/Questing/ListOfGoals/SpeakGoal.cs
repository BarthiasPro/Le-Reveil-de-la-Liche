using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakGoal : Goal
{
    public int pnjID;
    public SpeakGoal(int amountNeeded, int pnjID, Quest quest)
    {
        countCurrent = 0;
        countNeeded = amountNeeded;
        completed = false;
        this.quest = quest;
        this.pnjID = pnjID;
        EventController.OnPnjTalked += PnjTalked;
    }

    void PnjTalked(int pnjID)
    {
        if (this.pnjID == pnjID)
        {
            Increment(1);
            if (this.completed)
            {
                EventController.OnPnjTalked -= PnjTalked;
            }
        }
    }
}