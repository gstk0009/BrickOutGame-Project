using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEditor.Progress;

public class ItemBallApply : MonoBehaviour
{
    public ItemApplyManager applyManager;
    private Item item;
    private BallMovement ballMovement;

    private int itemId = 0;
    private bool isUseItemSpeed = false;
    private bool isUseItemSize = false;

    private void Awake()
    {
        ballMovement = GetComponent<BallMovement>();
        applyManager = applyManager.GetComponent<ItemApplyManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            item = collision.GetComponent<Item>();
            itemId = item.Id;
        }

        if (itemId >= 1 && itemId <= 1000)
        {
            if ((itemId == 1 || itemId == 2) && !isUseItemSize)
            {
                isUseItemSize = true;
                applyManager.ApplyBallItemSize();
                Destroy(collision.gameObject);
            }
            else if ((itemId == 3 || itemId == 4) && !isUseItemSpeed)
            {
                isUseItemSpeed = true;
                // 현재 ball Speed를 받아와서, 아이템 Speed를 곱해준 뒤, 그걸 다시 ballMovment에 적용
                ballMovement.GetBallSpeed(applyManager.ApplyBallItemSpeed(ballMovement.SetBallSpeed()));
                Destroy(collision.gameObject);
            }
        }
    }

    public void GetUseItemSpeed(bool isuseItem, float initSpeed)
    {
        isUseItemSpeed = isuseItem;

        ballMovement.GetBallSpeed(initSpeed);
    }

    public void GetIsUseItemSize(bool isUseItem)
    {
        isUseItemSize = isUseItem;
    }

    public float SetItemSpeed()
    {
        return item.Speed;
    }

    public float SetItemSize()
    {
        return item.Size;
    }

    public bool SetIsUseItemSpeed()
    {
        return isUseItemSpeed;
    }

    public bool SetIsUseItemSize()
    {
        return isUseItemSize;
    }
}
