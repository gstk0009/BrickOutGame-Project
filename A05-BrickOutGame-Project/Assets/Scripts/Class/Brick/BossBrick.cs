using System;
using UnityEngine;

public class BossBrick : Brick
{
    private int MaxHP;

    private BossAttack bossAttack;
    private BrickManager bossBrickManager;

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
        SetHP(10);
        SetScore(100);
    }

    private void CheckBossHP()
    {
        // TODO :: 조건 수정
        if (HP == (int)(MaxHP * 0.70f) || HP == (int)(MaxHP * 0.3f))
        {
            bossAttack.BlindSkill();
        }
        if  (HP <= MaxHP * 0.5f)
        {
            bossAttack.CanCreateShield();
        }
    }

    private void BossDie()
    {
        
    }

    public void GetBreakBossBrickManager(BrickManager breakBrick)
    {
        brickManager = breakBrick;
    }

    protected override void BrickBreak()
    {
        BossDie();
        brickManager.GetBrickScore(Score);
        gameObject.SetActive(false);
    }

    protected override void OnCollisionEnter2D(Collision2D collision)
    {
        base.OnCollisionEnter2D(collision);
        CheckBossHP();
    }

}
