using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPaddle : Item
{
    protected override void Awake()
    {
        base.Awake();
        AddItemPaddle();
    }

    // Id : 1001 ~ 2000
    public ItemPaddle(string name, int id, float speedUp, float sizeUp) : base(name, id, speedUp, sizeUp)
    {

    }

    // Paddle 관련 아이템 ItemInventory에 추가
    private void AddItemPaddle()
    {
        inventory.GetItems(new ItemPaddle("PaddleSizeUp", 1001, 0f, 2f));
        inventory.GetItems(new ItemPaddle("PaddleSpeedUp", 1002, 2f, 0f));
        inventory.GetItems(new ItemPaddle("PaddleSizeDown", 1003, 0f, 0.5f));
        inventory.GetItems(new ItemPaddle("PaddleSpeedDown", 1004, 0.5f, 0f));
    }
}
