using System;
using UnityEngine;

public class BossBrick : Brick
{
    [SerializeField] private GameObject endingObj;

    private BossAttack bossAttack;
    private EndingManager endingManager;

    protected override void Awake()
    {
        base.Awake();

        endingManager = endingObj.GetComponent<EndingManager>();
        bossAttack = GetComponent<BossAttack>();
        BossInit();
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

    // 보스 HP에 따라 보스 Skill 실행
    private void CheckBossHP()
    {
        // HP 70, 30 일 때  -  Blind Skill
        if (HP == 70 || HP == 30)
        {
            bossAttack.BlindSkill();
        }
        // HP 50일 때 - Shield Skill
        if  (HP == 50)
        {
            bossAttack.ShieldSkill();
        }
    }

    private void BossDie()
    {
        endingManager.GameClear();
    }

    public void SetBreakBossBrickManager(BrickManager breakBrick)
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
