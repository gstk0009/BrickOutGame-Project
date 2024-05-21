using System;
using UnityEngine;

public class BossBrick : Brick
{
    private int MaxHP;

    private BossAttack bossAttack;

    protected override void Awake()
    {
        base.Awake();

        bossAttack = GetComponent<BossAttack>();
        BossInit();

        MaxHP = HP;
    }
    private void Start()
    {
        brickUI.UpdateBrickHPTxt(HP);
    }

    private void BossInit()
    {
        SetHP(100);
        SetScore(100);
    }

    private void CheckBossHP()
    {
        // TODO :: 조건 수정
        if (HP == (int)(MaxHP * 0.70f)+1 || HP == (int)(MaxHP * 0.3f)+1)
        {
            bossAttack.BlindSkill();
        }
        if  (HP <= MaxHP * 0.5f)
        {
            bossAttack.CanCreateShield();
        }
        if (HP == 0)
        {
            BossDie();
        }
    }

    private void BossDie()
    {
        
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        CheckBossHP();
        Debug.Log(HP);
    }

}
