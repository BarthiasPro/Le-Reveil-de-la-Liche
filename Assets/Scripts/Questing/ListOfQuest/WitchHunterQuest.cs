using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WitchHunterQuest : Quest
{
    private void Awake()
    {
        questName = "Witch Hunter";
        description = "Hunt some witches";
        itemRewards = new List<string>() { "Witch hat", "Witch broom" };
        goal = new KillGoal(2,1,this);
    }

    public override void Complete()
    {
        base.Complete();
    }
}
