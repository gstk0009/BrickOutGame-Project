using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class BossStage : MonoBehaviour
{
    [SerializeField] private TMP_Text bossHP;

    // 모두 임의설정
    private int bossMaxHP = 50;
    private int bossHp = 50;
    private int bossScore = 100;

    private GameObject Blind;
    private GameObject BossBrick;
    private GameObject Ball;

    private BrickManager brickManager;

    public void Awake()
    {
        brickManager = GetComponent<BrickManager>();
        bossHP.text = bossHp.ToString();
        BossBrick.SetActive(true);
        BossSkill();
    }

    private void BossGetAttck(int damage)
    {   
        // 보스블럭이 파괴 시 바로 게임종료? 
        // 보스블럭이 파괴되어도 다른 블럭이 남아있다면 그대로 진행?
        bossHp -= damage;
        if(bossHp <= 0)
        {
            bossHp = 0;
            BossBrick.SetActive(false);
            brickManager.GetBrickScore(bossScore);
        }
        bossHP.text = bossHp.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        BossGetAttck(1);
    }

    private IEnumerator BlindSkill(GameObject obj, float time)
    {
        // time 입력한 시간만큼 켜졌다가 0이되면 꺼지게 하기
        obj.SetActive(true);
        yield return new WaitForSecondsRealtime (time);
        obj.SetActive(false);
    }

    private IEnumerator SizeDownSkill(GameObject obj,float time)
    {
        obj.transform.localScale = new Vector2() * 0.8f;
        yield return new WaitForSecondsRealtime(time);
        // 다시 원래 사이즈로 변경하려면 어찌 해야하지?
    }


    public void BossSkill()
    {
        // 보스스테이지 스킬
        // 1. 보스 HP 70% 이하 & 30% 이하 일정시간 화면 가리기
        if (bossHp <= (bossMaxHP*0.7) || bossHp <= (bossMaxHP * 0.3))
        {
            BlindSkill(Blind, 3);
        }

        // 2. 보스 HP 50% 이하 일때 파괴된 블럭 다시 생성하기
        if (bossHp <= (bossMaxHP * 0.5))
        {
            // 파괴된 블럭을 리스트에 저장하여 꺼내기(방법을 모르겠음)


        }

        // 3. 보스 HP 20% 이하 일때 볼 또는 패들 사이즈 줄이기
        if (bossHp <= (bossMaxHP * 0.2))
        {
            SizeDownSkill(Ball,2);
        }
    }

}
