using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Brick :MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private int Score;
    [SerializeField] private SpriteRenderer spriteRenderer;

    private BrickManager brickManager;
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
            brickManager.AddList(gameObject);
            brickManager.GetBrickScore(Score);
            gameObject.SetActive(false);
        }
        brickUI.UpdateBrickHPTxt( HP );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
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

    public void SetSpriteRenderer(int spriteIdx)
    {
        spriteRenderer = brickUI.SetSprite(spriteRenderer, spriteIdx);
    }

    public void GetBreakBrickManager(BrickManager breakBrick)
    {
        brickManager = breakBrick;
    }
}
