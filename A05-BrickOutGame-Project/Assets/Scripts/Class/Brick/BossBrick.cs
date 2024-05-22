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

    private void CheckBossHP()
    {
        if (HP == 70 || HP == 30)
        {
            bossAttack.BlindSkill();
        }
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
