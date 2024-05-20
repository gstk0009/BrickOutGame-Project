using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BallMovement : MonoBehaviour
{
    private GameController controller;
    private Vector2 BallMovementDirection = Vector2.zero;
    [SerializeField]private float speed = 10f;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        controller = GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update
    private void Start()
    {
        // 시작 시 공 내려오게 하기
        rb2d.velocity = Vector2.down * speed;
        controller.OnAimEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        BallMovementDirection = direction;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // gameObject의 Layer가 Paddle인지 확인
        Debug.Log(collision.gameObject.layer);
        if (collision.gameObject.layer == 6)
        {
            rb2d.velocity = BallMovementDirection * speed;
        }
    }

    public float SetBallSpeed()
    {
        return speed;
    }

    // applySpeed = 기존 speed * itemspeed
    public void GetBallSpeed(float applySpeed)
    {
        // 기존의 velocity 값 정규화를 시켜준 뒤 apply speed를 곱해줌
        Vector2 nwVelocity = rb2d.velocity.normalized;
        speed = applySpeed;
        rb2d.velocity = nwVelocity * speed;
    }

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.layer == 6)
    //    {
    //        rb2d.velocity = BallMovementDirection;
    //    }
    //}
}
