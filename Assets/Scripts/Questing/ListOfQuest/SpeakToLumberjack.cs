using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeakToLumberjack : Quest
{
    private void Awake()
    {
        questName = "SpeakToLumberjack";
        description = "Retourner voir le bûcheron";
        itemRewards = new List<string>() {"Gold coin"};
        goal = new SpeakGoal(1,1,this);
    }

    public override void Complete()
    {
        base.Complete();
    }
}
