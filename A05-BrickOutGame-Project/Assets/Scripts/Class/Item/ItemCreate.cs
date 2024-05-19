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
    public BreakBrickManager breakBrickManager;

    private int itemIndex;
    private int breakBrickNum;
    private float gameStartTime = 0f;
    private float itemCreateTime = 10.0f;

    private void Awake()
    {
        random = new System.Random();
        inventory = GetComponent<ItemInventory>();
        breakBrickManager = breakBrickManager.GetComponent<BreakBrickManager>();
    }
    private void Start()
    {
         
    }

    private void Update()
    {
        // 일정 시간마다 Item 생성 (단, 벽돌이 한 개 이상 파괴된 경우에만 생성됨)
        if (gameStartTime < itemCreateTime)
        {
            gameStartTime += Time.deltaTime;
            if (gameStartTime >= itemCreateTime)
            {
                breakBrickNum = breakBrickManager.SetIndex();
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

        breakBrickManager.SetActive(0);

        ////ItemInventory에 있는 Item 중 랜덤으로 생성
        //itemIndex = random.Next(0, inventory.ApplyItems());

        //// Test Paddle Size
        // itemIndex = random.Next(0, 2);

        //// Test Paddle Speed
        // itemIndex = random.Next(2, 4);

        //// Test Ball Size
        // itemIndex = random.Next(4, 6);

        //// Test Ball Speed
        //itemIndex = random.Next(6, 8);

        //// TODO : 지금은 편의상 Color로 지정, 추후 Sprite or Image로 변경 필요
        //items.GetComponent<SpriteRenderer>().color = itemImages[itemIndex].color;
        //// 파괴된 벽돌 위치 중 랜덤으로 생성
        //int createItemIndex = random.Next(0, breakBrickNum);
        //// 랜덤된 위치에 좌표값 가져오기
        //Vector2 createItemPosition = GameManager.Instance.BreakBrick[createItemIndex].GetComponent<Transform>().position;

        //// 아이템 생성될 때 해당 랜덤 위치로 좌표값 수정
        //items.GetComponent<Transform>().position = new Vector2(createItemPosition.x, createItemPosition.y);

        //// 아이템 생성
        //Instantiate(items).CreateItem(
        //inventory.SetItemStatsName(itemIndex), inventory.SetItemStatsId(itemIndex), inventory.SetItemStatsSpeed(itemIndex),
        //inventory.SetItemStatsSize(itemIndex));

        //// 생성 후 List에서 랜덤 선택된 Object 제거
        //GameManager.Instance.BreakBrick.RemoveAt(createItemIndex);
    }
}
