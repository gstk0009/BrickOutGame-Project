using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickManager : MonoBehaviour
{
    private List<GameObject> breakBrick = new List<GameObject>();

    public (int HP, int Score, int SpriteIdx, bool IsActive) BrickTypes(int type)
    {
        switch(type)
        {
            case 1:
                return (10,1,0, true);
            case 2:
                return (10,1,0,false);
            case 3:
                return (20,2,1,true);
            case 4:
                return (20,2,1,false);
            case 5:
                return (30,3,2,true);
            case 6:
                return (30,3,2,false);
            case 7:
                return (40,4,3,true);
            case 8:
                return (40,4,3,false);
            default:
                return (0, 0,0, false);

        }
    }

    public void AddList(GameObject brick)
    {
        Debug.Log(brick);
        breakBrick.Add(brick);
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
}
