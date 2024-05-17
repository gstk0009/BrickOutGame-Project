using UnityEngine;

[System.Serializable]
public class BrickData
{
    public int HP;
    public int Score;
    public bool IsActive;
}

[System.Serializable]
public class BrickDataList
{
    public BrickData[] bricks;
}
