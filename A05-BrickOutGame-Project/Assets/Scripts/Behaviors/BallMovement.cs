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
    private Vector2 befordBallMovement;

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

        // 구석(모서리 쪽에 가면 빠져나오지 못함
        if (rb2d.velocity.y == 0f)
        {
            Debug.Log(befordBallMovement);
            //Vector2 nowVector = new Vector2(-befordBallMovement.x, befordBallMovement.y).normalized;
            //Vector2 nowVector = new Vector2(befordBallMovement.x, befordBallMovement.y);
            Vector2 nowVector = new Vector2(-befordBallMovement.x + 0.5f, befordBallMovement.y + 0.5f).normalized * speed;
            rb2d.velocity = nowVector;
        }
        befordBallMovement = rb2d.velocity;
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

}
