using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.InputSystem;

public class BallImpactMovement : MonoBehaviour
{
    private GameController controller;
    private Vector2 BallMovementDirection = Vector2.zero;
    private float speed = 10f;

    private void Awake()
    {
        controller = GetComponent<GameController>();  
    }

    private void Start()
    {
        controller.OnAimEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        BallMovementDirection = direction * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collision.GetComponent<Rigidbody2D>().velocity = BallMovementDirection;
    }
}
