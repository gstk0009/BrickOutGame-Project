using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private GameController controller;
    private Vector2 BallMovementDirection = Vector2.zero;
    private Vector2 worldPos = Vector2.zero;
    private Vector2 befordBallMovement;

    [SerializeField] private float speed;
    private float initSpeed;
    private float initSizex;
    private float initSizey;
    private Rigidbody2D rb2d;
    private bool isHitSide = false;
    private bool isHitTop = false;


    private void Awake()
    {
        controller = GetComponent<GameController>();
        rb2d = GetComponent<Rigidbody2D>();
        initSpeed = speed;
        initSizex = transform.localScale.x;
        initSizey = transform.localScale.y;
    }

    private void Start()
    {
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

        // RigidBody Material로 인해 y 값이 일정 이하가 되면 0이 되는데 이때 보정
        if (isHitTop)
        {
            if (rb2d.velocity.y == 0f && rb2d.velocity.x > 9f)
            {
                Vector2 nowVector = new Vector2(befordBallMovement.x - 0.5f, -befordBallMovement.y - 0.5f).normalized * speed;
                rb2d.velocity = nowVector;
            }
            else if (rb2d.velocity.y == 0f && rb2d.velocity.x < -9f)
            {
                Vector2 nowVector = new Vector2(befordBallMovement.x + 0.5f, -befordBallMovement.y - 0.5f).normalized * speed;
                rb2d.velocity = nowVector;
            }
        }
        else
            isHitTop = false;

        if (isHitSide)
        {
            if (rb2d.velocity.y == 0f && rb2d.velocity.x > 9f)
            {
                if (befordBallMovement.y > 0f)
                {
                    Vector2 nowVector = new Vector2(-befordBallMovement.x + 0.5f, befordBallMovement.y + 0.5f).normalized * speed;
                    rb2d.velocity = nowVector;
                }
                else if (befordBallMovement.y < 0f)
                {
                    Vector2 nowVector = new Vector2(-befordBallMovement.x + 0.5f, befordBallMovement.y - 0.5f).normalized * speed;
                    rb2d.velocity = nowVector;
                }
            }
            else if (rb2d.velocity.y == 0f && rb2d.velocity.x < -9f)
            {
                if (befordBallMovement.y > 0f)
                {
                    Vector2 nowVector = new Vector2(-befordBallMovement.x - 0.5f, befordBallMovement.y + 0.5f).normalized * speed;
                    rb2d.velocity = nowVector;
                }
                else if (befordBallMovement.y < 0f)
                {
                    Vector2 nowVector = new Vector2(-befordBallMovement.x - 0.5f, befordBallMovement.y - 0.5f).normalized * speed;
                    rb2d.velocity = nowVector;
                }
            }
        }
        else
            isHitSide = false;

        //if (rb2d.velocity.y == 0f && rb2d.velocity.x > 9f)
        //{
        //    Vector2 nowVector = new Vector2(befordBallMovement.x - 0.5f, -befordBallMovement.y - 0.5f).normalized * speed;
        //    rb2d.velocity = nowVector;
        //}
        //if (rb2d.velocity.y == 0f && rb2d.velocity.x < -9f)
        //{
        //    Vector2 nowVector = new Vector2(-befordBallMovement.x + 0.5f, -befordBallMovement.y - 0.5f).normalized * speed;
        //    rb2d.velocity = nowVector;
        //}

        befordBallMovement = rb2d.velocity;
    }

    private Vector2 ApplyMovement(Vector2 worldPos)
    {
        BallMovementDirection = (worldPos - (Vector2)transform.localPosition).normalized;
        Debug.Log(BallMovementDirection);
        if (BallMovementDirection.y <= 0.1f)
            BallMovementDirection = new Vector2(BallMovementDirection.x - 0.1f, 0.1f).normalized;
        return BallMovementDirection;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.BallCollisionAudio();
        // Top
        if (collision.gameObject.layer == 5)
        {
            isHitTop = true;
        }
        if (collision.gameObject.layer == 6)
        {
            rb2d.velocity = Vector2.zero;
            rb2d.velocity = ApplyMovement(worldPos) * speed;
        }
        // Left
        if (collision.gameObject.layer == 12)
        {
            isHitSide = true;
        }
    }

    public float SetBallSpeed()
    {
        return speed;
    }

    public void GetBallSpeed(float applySpeed)
    {
        Vector2 nwVelocity = rb2d.velocity.normalized;
        speed = applySpeed;
        rb2d.velocity = nwVelocity * speed;
    }

    public float SetInitSpeed()
    {
        return initSpeed;
    }

    public void GetInitSpeed(float initspeed)
    {
        speed = initspeed;
    }

    public float SetInitSizex()
    {
        return initSizex;
    }

    public float SetInitSizey()
    {
        return initSizey;
    }
}
