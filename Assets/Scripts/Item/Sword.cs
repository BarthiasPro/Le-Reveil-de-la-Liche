using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : Item
{
    private void Start()
    {
        itemID = 1;
        itemName = "Sword";
    }

    public void BuyItem()
    {
        Player player = FindObjectOfType<Player>();
        if(player.HasGold())
        {
            player.RemoveItemFromInventory("Gold coin");
            player.AddItemToInventory(itemName);
            EventController.ItemFound(itemID);
            Destroy(gameObject);
        }        
    }
}
