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
        return spriteRenderer; 
    }
}
