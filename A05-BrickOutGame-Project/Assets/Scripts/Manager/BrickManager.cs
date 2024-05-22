using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    private List<GameObject> breakBrick;
    private int breakBrickNum;
    private int MaxBrick;
    [SerializeField] private ScoreBoardUI scoreBoard;
    [SerializeField] private EndingManager endingManager;

    private void Awake()
    {
        breakBrick = new List<GameObject>();
        scoreBoard = scoreBoard.GetComponent<ScoreBoardUI>();
        endingManager = endingManager.GetComponent<EndingManager>();
    }

    private void Start()
    {
        if (GameManager.Instance.nowStageNum == 4) return;

        MaxBrick = GameManager.Instance.GameClear[0];
    }

    public (int HP, int Score, int SpriteIdx, bool IsActive) BrickTypes(int type)
    {
        switch(type)
        {
            case 1:
                return (3,10,0, true);
            case 2:
                return (3,10,0, false);
            case 3:
                return (5,20,1,true);
            case 4:
                return (5,20,1,false);
            case 5:
                return (7,30,2,true);
            case 6:
                return (7,30,2,false);
            case 7:
                return (9,40,3,true);
            case 8:
                return (9,40,3,false);
            default:
                return (0, 0,0, false);

        }
    }

    public void AddList(GameObject brick)
    {
        breakBrick.Add(brick);
        breakBrickNum += 1;

        if (MaxBrick == breakBrickNum)
        {
            endingManager.StageClear();
        }
    }
    public void RemoveList(int index)
    {
        breakBrick.RemoveAt(index);
    }

    public void SetActive(int index)
    {
        breakBrick[index].gameObject.SetActive(true);
    }

    public Vector2 SetPosition(int index)
    {
        return breakBrick[index].GetComponent<Transform>().position;
    }

    public int SetIndex()
    {
        return breakBrick.Count; 
    }

    public void GetBrickScore(int score)
    {
        scoreBoard.GetBrickScore(score);
    }
    
    public ScoreBoardUI SetScoreBoardComponent()
    {
        return scoreBoard;
    }
}
