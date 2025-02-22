using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;   //�׼ǿ� ���� �̺�Ʈ ����

    public void CallMoveEvent(Vector2 direction)      //�̺�Ʈ�� invoke ��Ű�� �Լ�
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>().normalized;
        CallMoveEvent(moveInput);
    }
}
