using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    
    public int GameClear;
    public int BrickBreakNum;
    public int nowStageNum;
    public int maxStageNum;

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
}
