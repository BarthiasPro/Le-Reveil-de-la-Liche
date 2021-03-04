using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HuntTheWolf : Quest
{
    Bucheron bucheron;
    private void Awake()
    {
        questName = "HuntTheWolf";
        description = "Chasser le loup";
        itemRewards = new List<string>() {};
        goal = new KillGoal(1,0,this);
    }

    public override void Complete()
    {
        bucheron = FindObjectOfType<Bucheron>();
        bucheron.GiveQuest("SpeakToLumberjack");
        base.Complete();
    }
}
