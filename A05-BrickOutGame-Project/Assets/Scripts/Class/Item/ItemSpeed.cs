using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ItemSpeed : Item
{
    private readonly string[] itemName = { "BallSpeedUp", "BallSpeedDown" };
    private readonly float[] ballSpeed = { 1.5f, 0.8f };
    private float ballInitSpeed;

    public override void SetItmeInfo()
    {
        int index = UnityEngine.Random.Range(0, itemName.Length);

        name = itemName[index];
        speed = ballSpeed[index];
        image.sprite = itemSprite[index];
    }

    public override void UseItem()
    {
        UseItemSpeed().Forget();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            ballInitSpeed = GameManager.Instance.ballMovement.GetBallSpeed();
            GameManager.Instance.ballMovement.SetBallSpeed(ballInitSpeed * speed);
            UseItem();
        }
    }

    private async UniTask UseItemSpeed()
    {
        await UniTask.Delay(TimeSpan.FromSeconds(applyItemTime));

        GameManager.Instance.ballMovement.SetBallSpeed(ballInitSpeed);
    }
}
