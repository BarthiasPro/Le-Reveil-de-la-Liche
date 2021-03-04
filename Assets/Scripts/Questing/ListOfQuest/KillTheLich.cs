using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillTheLich : Quest
{
    private void Awake()
    {
        questName = "KillTheLich";
        description = "Éliminer la Liche";
        itemRewards = new List<string>() { "Diamant" };
        goal = new KillGoal(1,1,this);
    }

    public override void Complete()
    {
        base.Complete();
        UnityEngine.SceneManagement.SceneManager.LoadScene("WinScreen");
    }
}
