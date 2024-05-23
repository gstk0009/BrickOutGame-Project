using System.IO;
using UnityEditor.EditorTools;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    private ObjectPoolManager poolManager;
    private BrickTypeList brickTypeList;
    private int maxBrick = 0;

    [SerializeField] private GameObject BossBrick;
    [SerializeField] private BrickManager brickManager;

    private void Awake()
    {
        brickManager = brickManager.GetComponent<BrickManager>();
        poolManager = GetComponent<ObjectPoolManager>();
    }
    private void Start()
    {
        LoadData();
        LevelPoolSpawn();
    }

    private void LoadData()
    {
        string filePath = Path.Combine(Application.streamingAssetsPath, $"level{GameManager.Instance.nowStageNum}.json");
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            brickTypeList = JsonUtility.FromJson<BrickTypeList>(dataAsJson);
        }
    }

    private void LevelPoolSpawn()
    {
        int idx = 0;
        maxBrick = 0;
        GameManager.Instance.BrickBreakNum = 0;

        for (int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                int brickType = brickTypeList.brickTypes[idx].Type;
                var brickInfo = brickManager.BrickTypes(brickType);
                if (!brickManager.BrickTypes(brickType).IsActive)
                {
                    poolManager.DisableObj(poolManager.pool[i, j]); 
                }
                else
                {
                    Brick brick = poolManager.pool[i, j].GetComponent<Brick>();
                    if (brick != null)
                    {
                        brick.SetHP(brickInfo.HP);
                        brick.SetScore(brickInfo.Score);
                        brick.SetSpriteRenderer(brickInfo.SpriteIdx);

                        brick.GetBreakBrickManager(brickManager);
                        maxBrick += 1;
                    }
                }
                idx += 1;
            }
        }
        GameManager.Instance.GameClear = maxBrick;
        if (GameManager.Instance.nowStageNum == 3)
        {
            Level3();
        }
        if (GameManager.Instance.nowStageNum == 4)
        {
            Level4();
        }
    }

    private void Level3()
    {
        for (int i = 1;i < 5;i++)
        {
            for (int j= 1; j < 5; j++)
            {
                Brick brick = poolManager.pool[i, j].GetComponent<Brick>();
                int[] idxs = { 1, 3, 5, 7 };
                int type = idxs[Random.Range(0, 4)];
                var brickInfo = brickManager.BrickTypes(type);
                if (brick != null)
                {
                    brick.SetHP(brickInfo.HP);
                    brick.SetScore(brickInfo.Score);
                    brick.SetSpriteRenderer(brickInfo.SpriteIdx);

                    brick.GetBreakBrickManager(brickManager);
                }
            }
        }
    }

    private void Level4()
    {
        BossBrick.SetActive(true);
        BossBrick.GetComponent<BossBrick>().SetBreakBossBrickManager(brickManager);
    }
}