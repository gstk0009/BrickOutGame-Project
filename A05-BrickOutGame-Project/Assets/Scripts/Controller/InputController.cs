using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;   //액션에 사용될 이벤트 생성

    public void CallMoveEvent(Vector2 direction)      //이벤트를 invoke 시키는 함수
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
}
