using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleMovement : MonoBehaviour
{
    private GameController controller;
    private Rigidbody2D movementRigidbody;
    private Vector2 movementDirection = Vector2.zero;
    [SerializeField]private float speed = 10f;

    private void Awake()
    {
        controller = GetComponent<GameController>();
        movementRigidbody = GetComponentInChildren<Rigidbody2D>();
    }

    private void Start()
    {
        controller.OnMoveEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
    }

    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    private void ApplyMovement(Vector2 direction)
    {
        direction *= speed;
        movementRigidbody.velocity = direction;
    }

    public float SetPaddleSpeed()
    {
        return speed;
    }

    public void GetPaddleSpeed(float applySpeed)
    {
        speed = applySpeed;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            movementRigidbody.velocity = Vector3.zero;
        }
    }
}

