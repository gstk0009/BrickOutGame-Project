using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    private List<GameObject> breakBrick;
    private List<bool> isCreatedItem;
    private List<bool> isCreatedBrick;
    private int breakBrickNum;
    private int MaxBrick;
    private int nowStageNum;
    [SerializeField] private ScoreBoardUI scoreBoard;
    [SerializeField] private EndingManager endingManager;
    System.Random rand;

    private void Awake()
    {
        breakBrick = new List<GameObject>();
        isCreatedItem = new List<bool>();
        isCreatedBrick = new List<bool>();
        scoreBoard = scoreBoard.GetComponent<ScoreBoardUI>();
        endingManager = endingManager.GetComponent<EndingManager>();
        rand = new System.Random();
    }

    private void Start()
    {
        nowStageNum = GameManager.Instance.nowStageNum;
        if (nowStageNum == 4) return;
        MaxBrick = GameManager.Instance.GameClear;
        breakBrickNum = 0;
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

    public void BreakBrickList(GameObject brick)
    {
        breakBrickNum = GameManager.Instance.BrickBreakNum;
        breakBrick.Add(brick);

        if (MaxBrick == breakBrickNum)
        {
            endingManager.StageClear();
        }
        brickResponStage3();
    }

    private void brickResponStage3()
    {
        if (nowStageNum == 3 && (breakBrickNum % 4 == 0))
        {
            while (true)
            {
                int createIndex = rand.Next(0, breakBrick.Count);

                if (!isCreatedItem[createIndex] && !isCreatedBrick[createIndex])
                {
                    SetActive(createIndex);
                    MaxBrick += 1;
                    return;
                }
            }
        }
    }

    public void AddisCreatedList(bool isitemCreated, bool isbrickCreated)
    {
        isCreatedItem.Add(isitemCreated);
        isCreatedBrick.Add(isbrickCreated);
    }

    public void GetIsCreatedItem(int index, bool isCreated)
    {
        isCreatedItem[index] = isCreated;
    }

    public void GetIsCreatedBrick(int index, bool isCreated)
    {
        isCreatedBrick[index] = isCreated;
    }

    public void SetActive(int index)
    {
        Brick brick = breakBrick[index].GetComponent<Brick>();
        brick.ResponHp();
        isCreatedBrick[index] = true;
        brick.gameObject.SetActive(true);
    }

    public void Activefalse(int index)
    {

    }

    public bool SetIsCreatedItem(int index)
    {
        return isCreatedItem[index];
    }

    public bool SetIsCreatedBrick(int index)
    {
        return isCreatedBrick[index];
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
