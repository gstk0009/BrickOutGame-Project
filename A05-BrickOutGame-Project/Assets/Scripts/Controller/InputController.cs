using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : GameController
{
    private Camera cameras;

    public void Awake()
    {
        cameras = Camera.main;
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }

    public void OnAim(InputValue value)
    {
        Vector2 newAim = value.Get<Vector2>();
        Vector2 worldPos = cameras.ScreenToWorldPoint(newAim);

        CallAimEvent(worldPos);
    }
}
