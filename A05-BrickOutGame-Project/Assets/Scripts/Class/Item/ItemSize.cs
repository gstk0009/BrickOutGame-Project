using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSize : Item
{
    [SerializeField] private Sprite[] sprite;
    private readonly string[] itemName = { "Size Up", "Size Down" };
    private readonly float[] ballSize = { 1.5f, 0.8f };
    private float ballInitSizeX;
    private float ballInitSizeY;

    public override void SetItmeInfo(int createIndex)
    {
        this.createIndex = createIndex;
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        int index = UnityEngine.Random.Range(0, itemName.Length);

        spriteRenderer.sprite = sprite[index];
        size = ballSize[index];
        text.text = itemName[index];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            ballInitSizeX = collision.gameObject.transform.localScale.x;
            ballInitSizeY = collision.gameObject.transform.localScale.y;

            GameManager.Instance.ballMovement.SetBallSize(ballInitSizeX * size, ballInitSizeY * size);
            GameManager.Instance.brickManager.SetIsCreatedItem(createIndex, false);

            GameManager.Instance.itemManager.UseItemSize(applyItemTime, ballInitSizeX, ballInitSizeY).Forget();

            Destroy(gameObject);
        }
    }
}
