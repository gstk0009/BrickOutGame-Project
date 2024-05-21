using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ItemApplyManager : MonoBehaviour
{
    public ItemBallApply ballApply;
    //public ItemPaddleApply paddleApply;
    //private Item item;
    private Transform ballTransform;
    //private Transform paddleTransform;

    //private float itemId;
    private float itemSpeed;
    private float itemSize;
    
    private float ballInitSpeed;
    private float ballInitSizex;
    private float ballInitSizey;
    //private float paddleInitSpeed;
    //private float paddleInitSizex;
    //private float paddleInitSizey;

    private bool ballSpeed;
    private bool ballSize;
    //private bool paddleSpeed;
    //private bool paddleSize;

    private void Awake()
    {
        ballApply = ballApply.GetComponent<ItemBallApply>();
        ballTransform = ballApply.GetComponent <Transform>();
        //paddleApply = paddleApply.GetComponent<ItemPaddleApply>();
        //paddleTransform = paddleApply.GetComponent<Transform>();
    }

    // 충돌된 Item Speed 값 Ball에 적용하기
    public float ApplyBallItemSpeed(float speed)
    {
        ballInitSpeed = speed;

        itemSpeed = ballApply.SetItemSpeed();

        ballSpeed = ballApply.SetIsUseItemSpeed();

        return ballInitSpeed * itemSpeed;
    }

    // 충돌된 Item Size 값 Ball에 적용하기
    public void ApplyBallItemSize()
    {
        Transform size = ballTransform;

        ballInitSizex = size.localScale.x;
        ballInitSizey = size.localScale.y;

        itemSize = ballApply.SetItemSize();

        size.localScale = new Vector2(ballInitSizex * itemSize, ballInitSizey * itemSize);

        ballSize = ballApply.SetIsUseItemSize();
    }

    // 충돌된 Item Size 값 Paddle에 적용하기
    //public void ApplyPaddleItemSpeed()
    //{
    //    paddleInitSpeed = paddleApply.SetSpeed();

    //    itemSpeed = ballApply.SetItemSpeed();

    //    paddleSpeed = true;

    //    paddleApply.GetSpeed(paddleInitSpeed * itemSpeed);
    //}

    // 충돌된 Item Size 값 Paddle에 적용하기
    //public void ApplyPaddleItemSize()
    //{
    //    Transform size = paddleTransform;
    //    paddleInitSizex = size.localScale.x;
    //    paddleInitSizey = size.localScale.y;

    //    itemSize = ballApply.SetItemSize();

    //    size.localScale = new Vector2(paddleInitSizex * itemSize, paddleInitSizey);

    //    paddleSize = true;
    //}
}
