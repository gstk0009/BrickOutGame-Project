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
    private Rigidbody2D rb2d;

    private void Awake()
    {
        mainCamera = Camera.main;
        rb2d = GetComponent<Rigidbody2D>();
        initSpeed = speed;
        initSizex = transform.localScale.x;
        initSizey = transform.localScale.y;
    }

    private void Start()
    {
        GameManager.Instance.ballMovement = this;
        rb2d.velocity = Vector2.down * speed;
    }

    private void FixedUpdate()
    {
        // TODO : Ball Bounce Logic
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        AudioManager.Instance.BallCollisionAudio();
        if (collision.gameObject.layer == 6)
        {
            RaycastHit2D hitRight = Physics2D.Raycast(transform.position, transform.right, 1f, paddleLayerMask);
            RaycastHit2D hitLeft = Physics2D.Raycast(transform.position, -transform.right, 1f, paddleLayerMask);
            // Paddle ����� �浹������
            if (hitRight.collider != null || hitLeft.collider != null)
            {
                // ����ĳ��Ʈ�� Paddle ���̾ �浹�� ���
                Debug.Log("����");
            }
            else
            {
                // ����ĳ��Ʈ�� Paddle ���̾ �浹���� ���� ���
                rb2d.velocity = ApplyMovement(MousePosition()) * speed;
                Debug.Log("����");
            }
        }
    }

    public void BallInfoReset()
    {
        speed = initSpeed;
        transform.localScale = new Vector2(initSizex, initSizey);
        rb2d.velocity = Vector2.down * speed;
    }

    public void ResetPosition() { transform.position = Vector2.zero; }

    public float GetBallSpeed() { return speed; }

    public void SetBallSize(float x, float y) { gameObject.transform.localScale = new Vector2(x, y); }

    public void SetBallSpeed(float applySpeed)
    {
        Vector2 nwVelocity = rb2d.velocity.normalized;
        speed = applySpeed;
        rb2d.velocity = nwVelocity * speed;
    }

    private Vector2 MousePosition()
    {
        return mainCamera.ScreenToWorldPoint(Input.mousePosition);
    }

    private Vector2 ApplyMovement(Vector2 worldPos)
    {
        BallMovementDirection = (worldPos - (Vector2)transform.localPosition).normalized;

        // ���� �Ѱ� ����
        if (BallMovementDirection.y <= 0.1f)
            BallMovementDirection = new Vector2(BallMovementDirection.x - 0.1f, 0.1f).normalized;

        return BallMovementDirection;
    }
}
