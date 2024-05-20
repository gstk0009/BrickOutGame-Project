﻿using System.Collections;
using TMPro;
using UnityEngine;

public class BossStage : MonoBehaviour
{
    [SerializeField] private TMP_Text bossHP;

    // 보스 HP (임의설정)
    private int bossHp = 100;

    private GameObject Blind;
    private GameObject BossBrick;

    public void Awake()
    {
        bossHP.text = bossHp.ToString();
        BossOn();
        BossSkill();
    }

    public void BossOn()
    {
        BossBrick.SetActive(true);
    }

    private IEnumerator BlindSkill(float time)
    {
        // 일정시간 켜졌다 꺼지게 하기
        Blind.SetActive(true);
        yield return new WaitForSecondsRealtime (time);
        Blind.SetActive (false);
    }



    public void BossSkill()
    {
        // 보스스테이지 스킬
        // 1. 보스 HP 70% 이하 & 30% 이하 일정시간 화면 가리기
        if (bossHp <= (bossHp*0.7) || bossHp <= (bossHp * 0.3))
            BlindSkill(3);

        // 2. 보스 HP 50% 이하 일때 파괴된 블럭 다시 생성하기
        // 파괴된 블럭을 리스트에 저장하여 다시 켜야하는지?



        // 3. 보스 HP 20% 이하 일때 볼 또는 패들 사이즈 줄이기
    }

}
