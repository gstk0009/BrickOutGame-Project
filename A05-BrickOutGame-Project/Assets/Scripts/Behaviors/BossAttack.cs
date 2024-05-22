using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject BlindSkillCanvas;
    [SerializeField] private GameObject ShieldSkillCanvas;
    
    [SerializeField] private BrickManager brickManager;

    private void Awake()
    {
        brickManager = brickManager.GetComponent<BrickManager>();
    }

    public void BlindSkill()
    {
        StartCoroutine(WaitTime( 5f, BlindSkillCanvas));
    }

    public void ShieldSkill()
    {
        int breakBrickIdx = brickManager.SetIndex();
        if (breakBrickIdx !=0)
        {
            StartCoroutine(WaitTime(2f, ShieldSkillCanvas));
            List<int> idxs = new List<int>();
            for (int i = 0; i < breakBrickIdx; i++)
            {
                idxs.Add(i);
            }
            for (int i = 0; i < breakBrickIdx / 2 ; i++)
            {
                int randomIndex = Random.Range(0, idxs.Count);
                int createBrickIdx = idxs[randomIndex];

                if (!brickManager.SetIsCreatedItem(createBrickIdx))
                {
                    idxs.RemoveAt(randomIndex);
                    brickManager.SetActive(createBrickIdx);
                }
                else
                    i -= 1;
            }
        } 
    }

    IEnumerator WaitTime(float time, GameObject obj) 
    {
        obj.SetActive(true);
        yield return new WaitForSeconds(time);
        obj.SetActive(false);
    }
}