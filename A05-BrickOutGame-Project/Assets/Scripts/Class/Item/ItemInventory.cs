using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class ItemInventory : MonoBehaviour
{
    // ItemBall_Id : 1 ~ 1000
    // ItemPaddle_Id :1001 ~ 2000 
    private List<string> itemInventoryName = new List<string>();
    private List<int> itemInventoryId = new List<int>();
    private List<float> itemInventorySpeed = new List<float>();
    private List<float> itemInventorySize = new List<float>();

    //private void Update()
    //{
    //    Debug.Log(itemInventoryName[0]);
    //    Debug.Log(itemInventoryId[0]);
    //    Debug.Log(itemInventorySpeed[0]);
    //    Debug.Log(itemInventorySize[0]);
    //}

    public void GetItemName(string name)
    {
        itemInventoryName.Add(name);
    }

    public void GetItemsId(int id)
    {
        itemInventoryId.Add(id);
    }

    public void GetItemsSpeed(float speed)
    {
        itemInventorySpeed.Add(speed);
    }

    public void GetItemsSize(float size)
    {
        itemInventorySize.Add(size);
    }

    public int ApplyItems()
    {
        return itemInventoryId.Count;
    }

    public string GetItemStatsName(int index)
    {
        return itemInventoryName[index];
    }

    public int GetItemStatsId(int index)
    {
        return itemInventoryId[index];
    }

    public float GetItemStatsSpeed(int index)
    {
        return itemInventorySpeed[index];
    }

    public float GetItemStatsSize(int index)
    {
        return itemInventorySize[index];
    }
}
