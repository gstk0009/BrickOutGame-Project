using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ItemPaddleApply : MonoBehaviour
{
    public ItemApplyManager applyManager;
    private Rigidbody2D rigidBody;
    private PaddleMovement paddleMovement;
    private Transform paddleTransform;

    private float speed;

    private void Awake()
    {
        applyManager = applyManager.GetComponent<ItemApplyManager>();
        rigidBody = GetComponent<Rigidbody2D>();
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
