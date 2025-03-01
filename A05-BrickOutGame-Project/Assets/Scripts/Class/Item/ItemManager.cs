using Cysharp.Threading.Tasks;
using System;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    [SerializeField] private Item[] ItemObjects;

    private int createItemAmount = 6;
    private int itemIndex;
    private int breakBrickNum;
    private int createItemIndex;
    private int nowCreateItemAmount = 0;
    private float itemCreateTime;

    private void Start()
    {
        GameManager.Instance.itemManager = this;

        itemCreateTime = GameManager.Instance.GetLvTime() / createItemAmount;
        createItemCycle().Forget();
    }

    private void create()
    {
        itemIndex = UnityEngine.Random.Range(0, ItemObjects.Length);

        // ������ ����
        Item item = Instantiate(ItemObjects[itemIndex]);

        // �ı��� ���� ��ġ �� �������� ����
        do { createItemIndex = UnityEngine.Random.Range(0, breakBrickNum); }
        while (GameManager.Instance.brickManager.GetIsCanNotCreate(createItemIndex));

        // ������ ��ġ�� ��ǥ�� ��������
        Vector2 createItemPosition = GameManager.Instance.brickManager.GetPosition(createItemIndex);

        // ������ �����ϰ� ���� ��ġ�� ���õ� ���� ��ġ�� ��ǥ������ ����
        item.gameObject.transform.position = new Vector2(createItemPosition.x, createItemPosition.y);

        item.SetItmeInfo(createItemIndex);

        GameManager.Instance.brickManager.SetIsCreatedItem(createItemIndex, true);
    }

    public async UniTask UseItemSize(float applyTime, float ballInitSizeX, float ballInitSizeY)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(applyTime));
        GameManager.Instance.ballMovement.SetBallSize(ballInitSizeX, ballInitSizeY);
    }

    public async UniTask UseItemSpeed(float applyTime, float ballInitSpeed)
    {
        await UniTask.Delay(TimeSpan.FromSeconds(applyTime));
        GameManager.Instance.ballMovement.SetBallSpeed(ballInitSpeed);
    }

    private async UniTask createItemCycle()
    {
        while (nowCreateItemAmount < createItemAmount)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(itemCreateTime), cancellationToken : this.GetCancellationTokenOnDestroy());

            breakBrickNum = GameManager.Instance.brickManager.GetIndex();
            if (breakBrickNum != 0) { create(); }
        }
    }
}
