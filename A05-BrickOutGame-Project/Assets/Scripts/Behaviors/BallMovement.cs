using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 BallMovementDirection = Vector2.zero;

    [SerializeField] private LayerMask paddleLayerMask;
    [SerializeField] private float speed;
    private float initSpeed;
    private float initSizex;
    private float initSizey;
    private Rigidbody2D ballRigidBody2D;
    private Vector2 beforeBallVelocity;
    private Vector2 newDirection;

    private void Awake()
    {
        mainCamera = Camera.main;
        ballRigidBody2D = GetComponent<Rigidbody2D>();
        initSpeed = speed;
        initSizex = transform.localScale.x;
        initSizey = transform.localScale.y;
    }

    private void Start()
    {
        GameManager.Instance.ballMovement = this;
        ballRigidBody2D.velocity = Vector2.down * speed;
    }

    private void Update()
    {
        beforeBallVelocity = ballRigidBody2D.velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.BallCollisionAudio();

        if (collision.gameObject.layer == 6)
        {
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, 1f, paddleLayerMask);
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -transform.right, 1f, paddleLayerMask);
            // Paddle 옆면과 충돌했으면
            if (hitRight.collider != null || hitLeft.collider != null)
            {
                // 레이캐스트가 Paddle 레이어에 충돌한 경우
                Debug.Log("옆면");
            }
            else
            {
                // 레이캐스트가 Paddle 레이어에 충돌하지 않은 경우
                ballRigidBody2D.velocity = ApplyMovement(MousePosition()) * speed;
                Debug.Log("윗면");
            }

            return;
        }

        Debug.Log($"-----------BallRigidBody2D ---- {ballRigidBody2D.velocity.normalized}-----------------");
        Debug.Log($"-----------BeforeBallVelocity ---- {beforeBallVelocity.normalized}-----------------");
        Debug.Log($"-----------CollisionContact ---- {collision.contacts[0].normal}-----------------");
        if (beforeBallVelocity.x == ballRigidBody2D.velocity.x * -1f && beforeBallVelocity.y == ballRigidBody2D.velocity.y * -1f)
        {
            newDirection = Vector2.Reflect(ballRigidBody2D.velocity.normalized, collision.contacts[0].normal);
        }

        if (ballRigidBody2D.velocity.normalized == Vector2.zero)
        {
            ballRigidBody2D.velocity = newDirection * speed;
        }

        newDirection = Vector2.Reflect(beforeBallVelocity.normalized, collision.contacts[0].normal);

        Debug.Log($"-----------NewDirection ---- {newDirection}-----------------");

        ballRigidBody2D.velocity = newDirection * speed;

        Debug.Log($"-----------Change ---- {ballRigidBody2D.velocity}-----------------");
    }

    public void BallInfoReset()
    {
        speed = initSpeed;
        transform.localScale = new Vector2(initSizex, initSizey);
        ballRigidBody2D.velocity = Vector2.down * speed;
    }

    public void ResetPosition() { transform.position = Vector2.zero; }

    public float GetBallSpeed() { return speed; }

    public void SetBallSize(float x, float y) { gameObject.transform.localScale = new Vector2(x, y); }

    public void SetBallSpeed(float applySpeed)
    {
        Vector2 nwVelocity = ballRigidBody2D.velocity.normalized;
        speed = applySpeed;
        ballRigidBody2D.velocity = nwVelocity * speed;
    }

    private Vector2 MousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 ApplyMovement(Vector2 worldPos)
    {
        BallMovementDirection = (worldPos - (Vector2)transform.localPosition).normalized;

        // 각도 한계 설정
        if (BallMovementDirection.y <= 0.1f)
            BallMovementDirection = new Vector2(BallMovementDirection.x - 0.1f, 0.1f).normalized;

        return BallMovementDirection;
    }
}
