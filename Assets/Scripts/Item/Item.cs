using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string itemName;
    public int itemID;


    public void PickupItem()
    {
        FindObjectOfType<Player>().AddItemToInventory(itemName);
        EventController.ItemFound(itemID);
        Destroy(gameObject);
    }
}
