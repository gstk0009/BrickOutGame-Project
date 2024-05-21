using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem.XR;

public class BallMovement : MonoBehaviour
{
    private GameController controller;
    private Vector2 BallMovementDirection = Vector2.zero;
    private Vector2 worldPos = Vector2.zero;
    [SerializeField] private float speed = 10f;
    private Rigidbody2D rb2d;

    private void Awake()
    {
        controller = GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    private void Start()
    {
        // ���� �� �� �������� �ϱ�
        rb2d.velocity = Vector2.down * speed;
        controller.OnAimEvent += Move;
    }

    private void Move(Vector2 direction)
    {
        worldPos = direction;
    }

    private void FixedUpdate()
    {
        Vector2 ballVelocity = rb2d.velocity;
        if (ballVelocity.magnitude != speed)
            rb2d.velocity = ballVelocity.normalized * speed;

        if (ballVelocity.y == 0.00f)
        {
            ballVelocity.y = rb2d.velocity.y;
            Vector2 nowVector = new Vector2(rb2d.velocity.x, ballVelocity.y);
            rb2d.velocity = ballVelocity.normalized * speed;
        }

    }

    private Vector2 ApplyMovement(Vector2 worldPos)
    {
        BallMovementDirection = (worldPos - (Vector2)transform.localPosition).normalized;
        return BallMovementDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.BallCollisionAudio();
        if (collision.gameObject.layer == 6)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.velocity = ApplyMovement(worldPos) * speed;
        }
    }

    

    public float SetBallSpeed()
    {
        return speed;
    }

    // applySpeed = ���� speed * itemspeed
    public void GetBallSpeed(float applySpeed)
    {
        // ������ velocity �� ����ȭ�� ������ �� apply speed�� ������
        Vector2 nwVelocity = rb2d.velocity.normalized;
        speed = applySpeed;
        rb2d.velocity = nwVelocity * speed;
    }

    // 1안 : velocity 의 y가 0이되면 0.05 이상으로 임의로 설정하기
    // 2안 : 법선벡터를 활용하여 반사되게 하기
    public Vector2 ExchangeVector(Rigidbody2D rigidbody2D)
    {
        Vector2 beforeVector = rigidbody2D.velocity;

        return beforeVector;
    }

    public void ExchangeVelocity(Vector2 vector2)
    {
        
    }
}
