using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPaddle : Item
{
    private ItemPaddle itemPaddle;

    protected override void Awake()
    {
        base.Awake();
        SetItemPaddle();
    }

    private void Start()
    {
    }

    private void SetItemPaddle()
    {
        // Instantiate(itemPaddle).
        SetItem("PaddleSizeUp", 1001, 0f, 1.5f);
        SetItem("PaddlelSizeDown", 1002, 0f, 0.8f);
        SetItem("PaddleSpeedUp", 1003, 1.5f, 0f);
        SetItem("PaddlelSpeedDown", 1004, 0.8f, 0f);
    }
}
