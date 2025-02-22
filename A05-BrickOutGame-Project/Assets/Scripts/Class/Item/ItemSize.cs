using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ItemSize : Item
{
    private readonly string[] itemName = { "BallSizeUp", "BallSizeDown" };
    private readonly float[] ballSize = { 1.5f, 0.8f };
    private float ballInitSizeX;
    private float ballInitSizeY;

    public override void SetItmeInfo()
    {
        int index = UnityEngine.Random.Range(0, itemName.Length);

        name = itemName[index];
        size = ballSize[index];
        image.sprite = itemSprite[index];
    }

    public override void UseItem()
    {
        UseItemSize().Forget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            Transform size = collision.gameObject.transform;

            ballInitSizeX = size.localScale.x;
            ballInitSizeY = size.localScale.y;

            size.localScale = new Vector2(ballInitSizeX * this.size, ballInitSizeY * this.size);

            UseItem();
        }
    }

    private async UniTask UseItemSize()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(applyItemTime));

        GameManager.Instance.ballMovement.SetBallSize(ballInitSizeX, ballInitSizeY);
    }
}
