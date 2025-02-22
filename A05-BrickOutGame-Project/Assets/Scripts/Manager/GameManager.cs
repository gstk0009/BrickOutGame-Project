using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameController gameController;
    public BallMovement ballMovement;
    public PaddleMovement paddleMovement;
    public BrickManager brickManager;

    public int GameClear;
    public int BrickBreakNum;
    public int nowStageNum;
    public int maxStageNum;

    private float[] lvTime = { 60f, 120f, 180f, 240f };

    public float GetLvTime() => lvTime[nowStageNum-1];

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        Init();
        
    }
    private void Init()
    {
        BrickBreakNum = 0;
        GameClear = 0;
        nowStageNum = 1;
        maxStageNum = 1;
    }

    public void ResetPosition()
    {
        ballMovement.ResetPosition();
        paddleMovement.ResetPosition();
    }
}
