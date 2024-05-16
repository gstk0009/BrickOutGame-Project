using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public event Action<Vector2> OnMoveEvent;   //액션에 사용될 이벤트 생성
    public event Action<Vector2> OnLookEvent;


    public void CallMoveEvent(Vector2 direction)      //이벤트를 invoke 시키는 함수
    {
        OnMoveEvent?.Invoke(direction);
    }

    public void CallLookEvent(Vector2 direction) 
    { 
        OnLookEvent?.Invoke(direction); 
    }       
}
