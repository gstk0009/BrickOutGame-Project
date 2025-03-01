using System.Collections.Generic;
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
    System.Random rand;

    private void Awake()
    {
        breakBrick = new List<GameObject>();
        isCreatedItem = new List<bool>();
        isCreatedBrick = new List<bool>();
        rand = new System.Random();
    }

    private void Start()
    {
        GameManager.Instance.brickManager = this;
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

        brickResponStage3();

        if (MaxBrick == breakBrickNum)
        {
            GameManager.Instance.gameController.StageClear();
        }
    }

    private void brickResponStage3()
    {
        if (nowStageNum == 3 && (breakBrickNum % 4 == 0))
        {
            int createIndex;
            do
            {
                createIndex = rand.Next(0, breakBrick.Count);
            }
            while (GetIsCanNotCreate(createIndex));

            SetActive(createIndex);
            MaxBrick += 1;
        }
    }

    public void AddisCreatedList(bool isitemCreated, bool isbrickCreated)
    {
        isCreatedItem.Add(isitemCreated);
        isCreatedBrick.Add(isbrickCreated);
    }

    public void SetIsCreatedItem(int index, bool isCreated)
    {
        isCreatedItem[index] = isCreated;
    }

    public void SetActive(int index)
    {
        Brick brick = breakBrick[index].GetComponent<Brick>();
        brick.ResponHp();
        isCreatedBrick[index] = true;
        brick.gameObject.SetActive(true);
    }

    public bool GetIsCanNotCreate(int index)
    {
        return (isCreatedItem[index] || isCreatedBrick[index]);
    }

    public Vector2 GetPosition(int index)
    {
        return breakBrick[index].transform.position;
    }

    public int GetIndex()
    {
        return breakBrick.Count; 
    }

    public void GetBrickScore(int score)
    {
        scoreBoard.GetBrickScore(score);
    }
}
