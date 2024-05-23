using UnityEngine;
using UnityEngine.Timeline;

public class PaddleMovement : MonoBehaviour
{
    private GameController controller;
    private Vector2 movementDirection = Vector2.zero;
    [SerializeField]private float speed = 10f;

    private void Awake()
    {
        controller = GetComponent<GameController>();
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
        Vector2 position = new Vector2(transform.position.x, transform.position.y);
        if (position.x <= -2.5f)
            position.x = -2.5f;
        if (position.x >= 2.7f)
            position.x = 2.7f;
        transform.position = position + direction * speed * Time.deltaTime;
    }
}

