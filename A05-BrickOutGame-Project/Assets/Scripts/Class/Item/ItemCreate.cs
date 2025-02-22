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
        // 일정 시간마다 Item 생성 (단, 벽돌이 한 개 이상 파괴된 경우에만 생성됨)
        // 추후 파괴된 벽돌 개수 기준, 점수 기준으로 변경 될 수도 있다.
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
        //ItemInventory에 있는 Item 중 랜덤으로 생성
        itemIndex = Random.Range(0, ItemObjects.Length);

        // 아이템 생성
        GameObject item = Instantiate(ItemObjects[itemIndex].gameObject);

        // 파괴된 벽돌 위치 중 랜덤으로 생성
        do { createItemIndex = Random.Range(0, breakBrickNum); }
        while (GameManager.Instance.brickManager.GetIsCanCreate(createItemIndex));

        // 랜덤된 위치에 좌표값 가져오기
        Vector2 createItemPosition = GameManager.Instance.brickManager.GetPosition(createItemIndex);

        // 아이템 생성하고 나서 위치값 선택된 랜덤 위치의 좌표값으로 설정
        item.transform.position = new Vector2(createItemPosition.x, createItemPosition.y);

        ItemObjects[itemIndex].SetItmeInfo();

       GameManager.Instance.brickManager.SetIsCreatedItem(createItemIndex, true);
    }
}
