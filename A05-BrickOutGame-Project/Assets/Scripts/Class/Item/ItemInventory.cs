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

    // 함수명 앞에 Get : Inventory List에 추가
    // 함수명 앞에 Set : Inventory List에서 해당 index 값 보내기
    public void AddItemName(string name)
    {
        itemInventoryName.Add(name);
    }

    public void AddItemsId(int id)
    {
        itemInventoryId.Add(id);
    }

    public void AddItemsSpeed(float speed)
    {
        itemInventorySpeed.Add(speed);
    }

    public void AddItemsSize(float size)
    {
        itemInventorySize.Add(size);
    }

    public int ApplyItems()
    {
        return itemInventoryId.Count;
    }

    public string SetItemStatsName(int index)
    {
        return itemInventoryName[index];
    }

    public int SetItemStatsId(int index)
    {
        return itemInventoryId[index];
    }

    public float SetItemStatsSpeed(int index)
    {
        return itemInventorySpeed[index];
    }

    public float SetItemStatsSize(int index)
    {
        return itemInventorySize[index];
    }
}
