using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemApplyManager : MonoBehaviour
{
    // TODO : Ball Class와 Paddle Class 에 ItemApplyManager Class 받아오게 하기
    private ItemInventory inventory;
    private ItemCreate itemCreate;

    private int itemIndex;
    private float itemSpeed;
    private float itemSize;

    private float initSpeed;
    private float initSize;

    private void Awake()
    {
        inventory = GetComponent<ItemInventory>();
        itemCreate = GetComponent<ItemCreate>();
    }

    private void Start()
    {
        itemIndex = itemCreate.GetIndexNum();
    }

    public float ApplyItemSpeed(float speed)
    {
        initSpeed = speed;

        itemSpeed = inventory.GetItemStatsSpeed(itemIndex);

        return speed * itemSpeed;
    }

    public float ApplyItemSize(float size)
    {
        initSize = size;

        itemSize = inventory.GetItemStatsSize(itemIndex);

        return size * itemSize;
    }
}
