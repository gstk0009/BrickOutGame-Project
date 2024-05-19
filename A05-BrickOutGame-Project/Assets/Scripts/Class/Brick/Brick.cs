using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Brick :MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private int Score;
    [SerializeField] private SpriteRenderer spriteRenderer;
    private BreakBrickManager breakBrickManager;
    private BrickUI brickUI;
    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        brickUI = GetComponent<BrickUI>();
        brickUI.UpdateBrickHPTxt(HP);
    }

    private void GetAttack(int damage)
    {
        HP -= damage;
        if (HP <= 0 )
        {
            HP = 0;
            breakBrickManager.AddList(gameObject);
            gameObject.SetActive(false);
        }
        brickUI.UpdateBrickHPTxt( HP );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO :: 아이템 등을 사용하여 공의 데미지가 늘어났을 때 수정
        GetAttack(1);
    }

    public void SetScore(int score)
    {
        Score = score;
    }

    public void SetHP(int hp)
    {
        HP = hp;
        brickUI.UpdateBrickHPTxt(HP);
    }

    public void SetSpriteRenderer(SpriteRenderer renderer)
    {
        spriteRenderer = renderer;
    }

    public void GetBreakBrickManager(BreakBrickManager breakBrick)
    {
        breakBrickManager = breakBrick;
    }
}
