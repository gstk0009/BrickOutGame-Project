using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Item : MonoBehaviour
{
    public string Name { get; private set; }
    public int Id { get; private set; }
    public float SpeedUp { get; private set; }
    public float SizeUp { get; private set; }

    protected ItemInventory inventory;

    public Item (string name, int id, float speedUp, float sizeUp)
    {
        Name = name;
        Id = id;
        SpeedUp = speedUp;
        SizeUp = sizeUp;
    }

    protected virtual void Awake()
    {
        inventory = GetComponent<ItemInventory>();
    }
}
