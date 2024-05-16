using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBall : Item
{
    protected override void Awake()
    {
        base.Awake();
        AddItemBall();
    }

    // Id : 1 ~ 1000
    public ItemBall(string name, int id, float speedUp, float sizeUp) : base(name, id, speedUp, sizeUp)
    {
        
    }

    // Ball 관련 아이템 ItemInventory에 추가
    private void AddItemBall()
    {
        inventory.GetItems(new ItemBall("BallSizeUp", 1, 0f, 2f));
        inventory.GetItems(new ItemBall("BallSpeedUp", 2, 2f, 0f));
        inventory.GetItems(new ItemBall("BallSizeDown", 3, 0f, 0.5f));
        inventory.GetItems(new ItemBall("BallSpeedDown", 4, 0.5f, 0f));
    }
}
