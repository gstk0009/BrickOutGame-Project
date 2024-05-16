using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    // ItemBall_Id : 1 ~ 1000
    // ItemPaddle_Id :1001 ~ 2000 
    private List<Item> itemInventory = new List<Item>();

    public void GetItems(Item item)
    {
        itemInventory.Add(item);
    }

    private void Update()
    {
        Debug.Log(itemInventory[0].Id);
    }
}
