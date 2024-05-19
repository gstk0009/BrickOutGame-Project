using TMPro;
using UnityEngine;

public class BrickUI : MonoBehaviour
{
    [SerializeField] private TMP_Text brickHP;
    public Sprite[] sprites;

    public void UpdateBrickHPTxt(int HP)
    {
        brickHP.text = HP.ToString();
    } 

    public SpriteRenderer SetSprite(SpriteRenderer spriteRenderer, int idx)
    {
        spriteRenderer.sprite = sprites[idx];
        //SetSpriteSize(spriteRenderer);
        return spriteRenderer; 
    }

    //public void SetSpriteSize(SpriteRenderer spriteRenderer)
    //{
    //    // 벽돌의 크기
    //    float brickWidth = 1.0f;
    //    float brickHeight = 0.4f;

    //    // 스프라이트의 크기
    //    float spriteWidth = spriteRenderer.sprite.bounds.size.x;
    //    float spriteHeight = spriteRenderer.sprite.bounds.size.y;

    //    // 스프라이트의 크기를 벽돌의 크기에 맞추기 위한 비율 계산
    //    float scaleX = brickWidth / spriteWidth;
    //    float scaleY = brickHeight / spriteHeight;

    //    // 스프라이트의 크기를 벽돌의 크기에 맞게 조정
    //    spriteRenderer.transform.localScale = new Vector3(scaleX, scaleY, 1.0f);
    //}
}
