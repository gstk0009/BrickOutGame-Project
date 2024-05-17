using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name;
    public int Id;
    public float Speed;
    public float Size;

    protected ItemInventory inventory;

    protected virtual void Awake()
    {
        inventory = GetComponent<ItemInventory>();
    }

    protected void SetItem(string name, int id, float speed, float size)
    {
        Name = name;
        Id = id;
        Speed = speed;
        Size = size;

        inventory.GetItemName(Name);
        inventory.GetItemsId(Id);
        inventory.GetItemsSpeed(Speed);
        inventory.GetItemsSize(Size);
    }

    public void CreateItem(string name, int id, float speed, float size)
    {
        Name = name;
        Id = id;
        Speed = speed;
        Size = size;
    }
}
