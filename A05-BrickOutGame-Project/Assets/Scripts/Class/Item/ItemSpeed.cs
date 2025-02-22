using Cysharp.Threading.Tasks;
using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemSpeed : Item
{
    [SerializeField] private Sprite[] sprite;
    private readonly string[] itemName = { "Speed Up", "Speed Down" };
    private readonly float[] ballSpeed = { 1.5f, 0.8f };
    private float ballInitSpeed;

    public override void SetItmeInfo(int createIndex)
    {
        this.createIndex = createIndex;
        spriteRenderer = GetComponent<SpriteRenderer>();
        text = transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();

        int index = UnityEngine.Random.Range(0, itemName.Length);

        spriteRenderer.sprite = sprite[index];
        speed = ballSpeed[index];
        text.text = itemName[index];
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            ballInitSpeed = GameManager.Instance.ballMovement.GetBallSpeed();
            GameManager.Instance.ballMovement.SetBallSpeed(ballInitSpeed * speed);
            GameManager.Instance.brickManager.SetIsCreatedItem(createIndex, false);

            GameManager.Instance.itemManager.UseItemSpeed(applyItemTime, ballInitSpeed).Forget();

            Destroy(gameObject);
        }
    }
}
