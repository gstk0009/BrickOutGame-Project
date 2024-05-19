using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrickManager : MonoBehaviour
{
    private List<GameObject> breakBrick = new List<GameObject>();
    private int num;


    public void AddList(GameObject brick)
    {
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

    public int SetIndex()
    {
        return breakBrick.Count;
    }
}
