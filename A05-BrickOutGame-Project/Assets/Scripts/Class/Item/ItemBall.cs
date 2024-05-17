using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemBall : Item
{
    private ItemBall itemBall;

    protected override void Awake()
    {
        base.Awake();
        SetItemBall();
    }

    private void Start()
    {
    }

    private void SetItemBall()
    {
        SetItem("BallSizeUp", 1, 0f, 2f);
        SetItem("BallSpeedUp", 2, 2f, 0f);
        SetItem("BallSizeDown", 3, 0f, 0.5f);
        SetItem("BallSpeedDown", 4, 0.5f, 0f);
    }
}
