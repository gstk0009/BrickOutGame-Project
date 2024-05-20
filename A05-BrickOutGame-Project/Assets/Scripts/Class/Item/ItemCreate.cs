using System.Collections;
using System.Collections.Generic;
using UnityEditor.UIElements;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] itemImages;
    private System.Random random;
    private ItemInventory inventory;
    // Prefabs에 있는 Item에 Script 받아옴
    public Item items;
    public BrickManager brickManager;

    private int itemIndex;
    private int breakBrickNum;
    private float gameStartTime = 0f;
    private float itemCreateTime = 10.0f;

    private void Awake()
    {
        random = new System.Random();
        inventory = GetComponent<ItemInventory>();
        brickManager = brickManager.GetComponent<BrickManager>();
    }

    //private void Update()
    //{
    //    // 일정 시간마다 Item 생성 (단, 벽돌이 한 개 이상 파괴된 경우에만 생성됨)
    //    // 추후 파괴된 벽돌 개수 기준, 점수 기준으로 변경 될 수도 있다.
    //    if (gameStartTime < itemCreateTime)
    //    {
    //        gameStartTime += Time.deltaTime;
    //        if (gameStartTime >= itemCreateTime)
    //        {
    //            breakBrickNum = brickManager.SetIndex();
    //            if (breakBrickNum != 0)
    //            {
    //                CreateItems();
    //            }
    //            gameStartTime = 0f;
    //        }
    //    }
    //}

    private void CreateItems()
    {
        ////ItemInventory에 있는 Item 중 랜덤으로 생성
        //itemIndex = random.Next(0, inventory.ApplyItems());

        //// Test Paddle Size
        // itemIndex = random.Next(0, 2);

        //// Test Paddle Speed
        // itemIndex = random.Next(2, 4);

        //// Test Ball Size
        // itemIndex = random.Next(4, 6);

        // Test Ball Speed
        itemIndex = random.Next(6, 8);

        // TODO : 지금은 편의상 Color로 지정, 추후 Sprite or Image로 변경 필요
        items.GetComponent<SpriteRenderer>().color = itemImages[itemIndex].color;
        // 파괴된 벽돌 위치 중 랜덤으로 생성
        int createItemIndex = random.Next(0, breakBrickNum);
        // 랜덤된 위치에 좌표값 가져오기
        Vector2 createItemPosition = brickManager.SetPosition(createItemIndex);

        // 아이템 생성될 때 해당 랜덤 위치로 좌표값 수정
        items.GetComponent<Transform>().position = new Vector2(createItemPosition.x, createItemPosition.y);

        // 아이템 생성
        Instantiate(items).CreateItem(
        inventory.SetItemStatsName(itemIndex), inventory.SetItemStatsId(itemIndex), inventory.SetItemStatsSpeed(itemIndex),
        inventory.SetItemStatsSize(itemIndex));

        // 생성 후 List에서 랜덤 선택된 Object 제거
        // List를 1개로 벽돌을 관리할 때, 여기서 Item의 bool 값을 True로 변경
        // 아이템이 사용되면 아이템은 Destroy로 파괴시킨다.
        brickManager.RemoveList(createItemIndex);
    }
}
