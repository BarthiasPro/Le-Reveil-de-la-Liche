using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetSword : Quest
{
    private void Awake()
    {
        questName = "GetSword";
        description = "Récupérer une arme";
        itemRewards = new List<string>() { };
        goal = new CollectionGoal(1,1,this);
    }

    public override void Complete()
    {
        base.Complete();
    }
}
