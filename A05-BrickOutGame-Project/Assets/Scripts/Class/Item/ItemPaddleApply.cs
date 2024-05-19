using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPaddleApply : MonoBehaviour
{
    public ItemApplyManager applyManager;
    private PaddleMovement paddleMovement;

    private float speed;

    private void Awake()
    {
        //applyManager = applyManager.GetComponent<ItemApplyManager>();
        paddleMovement = GetComponent<PaddleMovement>();
    }

    public float SetSpeed()
    {
        speed = paddleMovement.SetPaddleSpeed();
        return speed;
    }

    public void GetSpeed(float applySpeed)
    {
        speed = applySpeed;
        paddleMovement.GetPaddleSpeed(speed);
    }
}
