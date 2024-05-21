using System.IO;
using UnityEditor.EditorTools;
using UnityEngine;

public class LevelDataManager : MonoBehaviour
{
    private ObjectPoolManager poolManager;
    private BrickTypeList brickTypeList;

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
        string filePath = Path.Combine(Application.streamingAssetsPath, $"level{GameManager.Instance.stageNum}.json");
        if (File.Exists(filePath))
        {
            string dataAsJson = File.ReadAllText(filePath);
            brickTypeList = JsonUtility.FromJson<BrickTypeList>(dataAsJson);
        }
    }

    private void LevelPoolSpawn()
    {
        int idx = 0;

        for (int i = 0; i < 6; i++)
        {
            for(int j = 0; j < 6; j++)
            {
                // brickTypeList에서 벽돌 정보 불러오기
                int brickType = brickTypeList.brickTypes[idx].Type;
                var brickInfo = brickManager.BrickTypes(brickType);
                // brickInfo 값을 통해 벽돌에 값 넣어주기
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

                        // 각 벽돌에 동일한 brickManager값 넣어주기
                        brick.SetBreakBrickManager(brickManager);
                    }
                }
                idx += 1;
            }
        }
        if (GameManager.Instance.stageNum == 3)
        {
            Level3();
        }
        if (GameManager.Instance.stageNum == 4)
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

                    // 각 벽돌에 동일한 brickManager값 넣어주기
                    brick.SetBreakBrickManager(brickManager);
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