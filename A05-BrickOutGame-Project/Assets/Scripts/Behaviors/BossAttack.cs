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
        // 부서진 벽돌 블럭 개수가 0이상일 때만 실행
        if (breakBrickIdx !=0)
        {
            StartCoroutine(WaitTime(2f, ShieldSkillCanvas));
            List<int> idxs = new List<int>();
            for (int i=0; i < breakBrickIdx; i++)
            {
                idxs.Add(i);
            }
            // 현재 부서진 벽돌 중 절반 부활시키기
            for (int i = 0; i < breakBrickIdx / 2 ; i++)
            {
                int randomIndex = Random.Range(0, idxs.Count);
                int createBrickIdx = idxs[randomIndex];

                // 선택된 인덱스를 리스트에서 제거
                idxs.RemoveAt(randomIndex);
                brickManager.SetActive(createBrickIdx);
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