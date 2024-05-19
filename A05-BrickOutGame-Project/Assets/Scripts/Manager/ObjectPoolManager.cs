using System.Collections.Generic;
using UnityEngine;

public class ObjectPoolManager : MonoBehaviour
{
    [SerializeField] private GameObject brickObj;
    [SerializeField] public GameObject[,] pool = new GameObject[6,6];

    private void Awake()
    {
        SpawnPool();
    }

    private void SpawnPool()
    {
        float posX = -2.35f;
        float posY = 3f;

        for (int i = 0; i<6; i++)
        {
            for (int j = 0; j<6; j++)
            {
                GameObject brick = Instantiate(brickObj);
                brick.transform.SetParent(gameObject.transform, false);
                brick.transform.position = new Vector2(posX, posY);
                pool[i, j] = brick;
                posX += 1f;
            }
            posX = -2.35f;
            posY -= 0.4f;
        }
    }

    public void EnableObj(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void DisableObj(GameObject obj)
    {
        obj.SetActive(false);
    }
}
