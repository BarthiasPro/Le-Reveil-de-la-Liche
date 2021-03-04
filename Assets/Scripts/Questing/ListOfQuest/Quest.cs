using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public string questName;
    public string description;
    public Goal goal;
    public Player player;
    public bool completed;
    public List<string> itemRewards;

    public virtual void Complete()
    {
        completed = true;
        Debug.Log("Quest completed !");
        EventController.QuestCompleted(this);
        GrantReward();
    }

    public void GrantReward()
    {
        Debug.Log("Turning in quest... granting reward.");
        player = FindObjectOfType<Player>();
        foreach(string item in itemRewards)
        {
            Debug.Log("Rewarded with: " + item);
            player.AddItemToInventory(item);

        }
        Destroy(this);
    }
}
