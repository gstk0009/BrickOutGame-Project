using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakBrickManager : MonoBehaviour
{
    private List<GameObject> breakBrick = new List<GameObject>();
    private int num;


    public void GetList(GameObject brick)
    {
        breakBrick.Add(brick);
    }

    public void RemoveList(int index)
    {
        breakBrick.RemoveAt(index);
    }
}
