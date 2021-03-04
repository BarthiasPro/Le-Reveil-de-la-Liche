using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureHunterQuest : Quest
{
    private void Awake()
    {
        questName = "Treasure Hunter";
        description = "Find some Treasures";
        itemRewards = new List<string>() { "Ruby", "Bag of gold" };
        goal = new CollectionGoal(1,0,this);
    }

    public override void Complete()
    {
        base.Complete();
    }
}
