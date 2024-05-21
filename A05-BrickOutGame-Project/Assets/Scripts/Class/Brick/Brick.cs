using UnityEngine;

public class Brick :MonoBehaviour
{
    [SerializeField] protected int HP;
    [SerializeField] protected int Score;
    [SerializeField] protected SpriteRenderer spriteRenderer;

    protected BrickManager brickManager;
    protected BrickUI brickUI;

    protected virtual void Awake()
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

    protected virtual void OnCollisionEnter2D(Collision2D collision)
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
