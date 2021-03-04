using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VampireSlayerQuest : Quest
{
    private void Awake()
    {
        questName = "Vampire Slayer";
        description = "slay some vampires.";
        itemRewards = new List<string>() { "Vampire tooth", "Vampire ash" };
        goal = new KillGoal(5,0,this);
    }

    public override void Complete()
    {
        base.Complete();
    }
}
