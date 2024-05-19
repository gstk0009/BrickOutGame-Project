using System.IO;
using UnityEditor.EditorTools;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    private ObjectPoolManager poolManager;
    private BrickDataList brickDataList;
    [SerializeField] private BreakBrickManager brickManager;

    private void Awake()
    {
        brickManager = brickManager.GetComponent<BreakBrickManager>();
        poolManager = GetComponent<ObjectPoolManager>();    
    }
    private void Start()
    {
        LoadData();
        LevelPoolSpawn();
    }

    private void LoadData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, $"level{GameManager.Instance.stageNum}.json");
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            brickDataList = JsonUtility.FromJson<BrickDataList>(dataAsJson);
        }
    }

    private void LevelPoolSpawn()
    {
        int idx = 0;
        for (int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                if (!brickDataList.bricks[idx].IsActive)
                {
                    poolManager.DisableObj(poolManager.pool[i, j]);
                }
                else
                {
                    Brick brick = poolManager.pool[i, j].GetComponent<Brick>();
                    if (brick != null)
                    {
                        brick.SetHP(brickDataList.bricks[idx].HP);
                        brick.SetScore(brickDataList.bricks[idx].Score);
                        brick.GetBreakBrickManager(brickManager);
                    }
                }
                idx += 1;
            }
        }
    }
}