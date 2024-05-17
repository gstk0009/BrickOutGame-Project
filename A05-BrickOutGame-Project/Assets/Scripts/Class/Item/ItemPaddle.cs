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
        SetItem("PaddleSizeUp", 1001, 0f, 2f);
        SetItem("PaddleSpeedUp", 1002, 2f, 0f);
        SetItem("PaddlelSizeDown", 1003, 0f, 0.5f);
        SetItem("PaddlelSpeedDown", 1004, 0.5f, 0f);
    }
}
