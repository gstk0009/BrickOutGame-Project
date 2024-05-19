using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public int stageNum = 1;
    public List<GameObject> BreakBrick = new List<GameObject>();
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(Instance);
        }
    }

    // 1  2  3  4  5   6
    // 7 8 9 10 11 12

    // List            0      1      2
    // ÆÄ±«µÈ ¼ø¼­ 6 -> 8 -> 11
    // Id 6 index 0


}
