using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BallMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private CircleCollider2D cc2d;
    private GameController controller;
    private Vector2 ballVector;

    private void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
        controller = GetComponent<GameController>();
        cc2d = GetComponent<CircleCollider2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        rb2d.velocity = Vector2.down * 10;
        controller.OnAimEvent += AimMovementPoint;
    }

    private void FixedUpdate()
    {
        AimMovementPoint(ballVector);
    }

    private void AimMovementPoint(Vector2 vector)
    {
        ballVector = vector;
        BallMove(vector);
    }

    private void BallMove(Vector2 vector)
    {
        ballVector = vector * 5;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().velocity = ballVector;
    }

    





    // Update is called once per frame
    void Update()
    {

    }
}
