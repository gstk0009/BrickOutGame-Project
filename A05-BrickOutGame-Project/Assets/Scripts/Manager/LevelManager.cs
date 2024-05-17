using UnityEngine;

public class LevelManager : ObjectPoolManager
{
    protected override void Awake()
    {
        base.Awake();
        SetLevel();
    }

    private void SetLevel()
    {
        switch (GameManager.Instance.stageNum)
        {
            case 1:
                Level1();
                break;
            case 2:
                Level2();
                break;
            case 3:
                Level3();
                break;
            default:
                break;
        }
    }

    protected void Level1()
    {
        float posX = -2.8f;
        float posY = 3f;

        for (int i = 0; i < 2; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject brick = Instantiate(brickObj[0]);
                brick.transform.SetParent(gameObject.transform, false);
                brick.transform.position = new Vector2(posX, posY);
                pool.Add(brick);
                posX += 1.1f;
            }
            posX = -2.8f;
            posY -= 0.5f;
        }
    }

    private void Level2()
    {
        float posX = -2.8f;
        float posY = 3f;

        for (int i = 0; i < 4; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                GameObject brick = Instantiate(brickObj[3-i]);
                brick.transform.SetParent(gameObject.transform, false);
                brick.transform.position = new Vector2(posX, posY);
                pool.Add(brick);
                posX += 1.1f;
            }
            posX = -2.8f;
            posY -= 0.5f;
        }
    }

    private void Level3()
    {
        float posX = -2.8f;
        float posY = 3f;

        for (int i = 0; i < 6; i++)
        {
            for (int j = 0; j < 6; j++)
            {
                int idx = Random.Range(0, 4);
                GameObject brick = Instantiate(brickObj[idx]);
                brick.transform.SetParent(gameObject.transform, false);
                brick.transform.position = new Vector2(posX, posY);
                pool.Add(brick);
                posX += 1.1f;
            }
            posX = -2.8f;
            posY -= 0.5f;
        }
    }
}