using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private Item[] ItemObjects;

    private int crateItemAmount = 6;
    private int itemIndex;
    private int breakBrickNum;
    private int createItemIndex;
    private float gameStartTime = 0f;
    private float itemCreateTime;

    private void Start()
    {
        itemCreateTime = GameManager.Instance.GetLvTime() / crateItemAmount;
    }

    private void Update()
    {
        // ���� �ð����� Item ���� (��, ������ �� �� �̻� �ı��� ��쿡�� ������)
        // ���� �ı��� ���� ���� ����, ���� �������� ���� �� ���� �ִ�.
        if (gameStartTime < itemCreateTime)
        {
            gameStartTime += Time.deltaTime;
            if (gameStartTime >= itemCreateTime)
            {
                breakBrickNum = GameManager.Instance.brickManager.GetIndex();
                if (breakBrickNum != 0)
                {
                    CreateItems();
                }
                gameStartTime = 0f;
            }
        }
    }

    private void CreateItems()
    {
        //ItemInventory�� �ִ� Item �� �������� ����
        itemIndex = Random.Range(0, ItemObjects.Length);

        // ������ ����
        GameObject item = Instantiate(ItemObjects[itemIndex].gameObject);

        // �ı��� ���� ��ġ �� �������� ����
        do { createItemIndex = Random.Range(0, breakBrickNum); }
        while (GameManager.Instance.brickManager.GetIsCanCreate(createItemIndex));

        // ������ ��ġ�� ��ǥ�� ��������
        Vector2 createItemPosition = GameManager.Instance.brickManager.GetPosition(createItemIndex);

        // ������ �����ϰ� ���� ��ġ�� ���õ� ���� ��ġ�� ��ǥ������ ����
        item.transform.position = new Vector2(createItemPosition.x, createItemPosition.y);

        ItemObjects[itemIndex].SetItmeInfo();

       GameManager.Instance.brickManager.SetIsCreatedItem(createItemIndex, true);
    }
}
