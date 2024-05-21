using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    private List<GameObject> breakBrick;
    private List<GameObject> activeBrick;
    [SerializeField] private ScoreBoardUI scoreBoard;

    private void Awake()
    {
        breakBrick = new List<GameObject>();
        scoreBoard = scoreBoard.GetComponent<ScoreBoardUI>();
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
    }
    public void AddActiveBrickList(GameObject brick)
    {
        activeBrick.Add(brick);
    }
    public void RemoveList(int index)
    {
        breakBrick.RemoveAt(index);
    }
    public void RemoveActiveBrickList(int index)
    {
        activeBrick.RemoveAt(index);
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
}
