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

    private bool isUseItemSize = false;
    private bool isUseItemSpeed = false;

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
        while (GameManager.Instance.brickManager.GetIsCanCreate(createItemIndex));

        // ������ ��ġ�� ��ǥ�� ��������
        Vector2 createItemPosition = GameManager.Instance.brickManager.GetPosition(createItemIndex);

        // ������ �����ϰ� ���� ��ġ�� ���õ� ���� ��ġ�� ��ǥ������ ����
        item.gameObject.transform.position = new Vector2(createItemPosition.x, createItemPosition.y);

        item.SetItmeInfo(createItemIndex);

        GameManager.Instance.brickManager.SetIsCreatedItem(createItemIndex, true);
    }

    public async UniTask UseItemSize(float applyTime, float ballInitSizeX, float ballInitSizeY)
    {
        if (!isUseItemSize)
        {
            isUseItemSize = true;
            await UniTask.Delay(TimeSpan.FromSeconds(applyTime));
            GameManager.Instance.ballMovement.SetBallSize(ballInitSizeX, ballInitSizeY);
        }
        else
        {
            await UniTask.WaitUntil(() => isUseItemSize == false);
            await UniTask.Delay(TimeSpan.FromSeconds(applyTime));
            GameManager.Instance.ballMovement.SetBallSize(ballInitSizeX, ballInitSizeY);
        }

        isUseItemSize = false;
    }

    public async UniTask UseItemSpeed(float applyTime, float ballInitSpeed)
    {
        if (!isUseItemSpeed)
        {
            isUseItemSpeed = true;
            await UniTask.Delay(TimeSpan.FromSeconds(applyTime));
            GameManager.Instance.ballMovement.SetBallSpeed(ballInitSpeed);
        }
        else
        {
            await UniTask.WaitUntil(() => isUseItemSpeed == false);
            await UniTask.Delay(TimeSpan.FromSeconds(applyTime));
            GameManager.Instance.ballMovement.SetBallSpeed(ballInitSpeed);
        }

        isUseItemSpeed = false;
    }

    private async UniTask createItemCycle()
    {
        while (nowCreateItemAmount < createItemAmount)
        {
            await UniTask.Delay(TimeSpan.FromSeconds(itemCreateTime), cancellationToken : this.GetCancellationTokenOnDestroy());

            breakBrickNum = GameManager.Instance.brickManager.GetIndex();
            if (breakBrickNum != 0)
            {
                create();
            }
        }
    }
}
