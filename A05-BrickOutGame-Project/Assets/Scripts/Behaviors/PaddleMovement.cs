using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Timeline;

public class PaddleMovement : MonoBehaviour
{
    private InputController inputController;
    private Vector2 movementDirection = Vector2.zero;
    [SerializeField]private float speed = 10f;

    private void Awake()
    {
        inputController = GetComponent<InputController>();
    }

    private void Start()
    {
        inputController.OnMoveEvent += Move;
        GameManager.Instance.paddleMovement = this;
    }
    
    private void FixedUpdate()
    {
        ApplyMovement(movementDirection);
    }

    public void ResetPosition()
    {
        transform.position = Vector2.zero;
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;
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

