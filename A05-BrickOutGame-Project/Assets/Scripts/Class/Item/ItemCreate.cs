using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private GameObject[] ItemObjects;
    [SerializeField] private BrickManager brickManager;
    private System.Random random;
    private ItemInventory inventory;
    // Prefabs에 있는 Item에 Script 받아옴
    public Item items;
    // BrickManager에서 ScoreBoardUI 받아옴
    private ScoreBoardUI scoreBoard;

    private int itemIndex;
    private int breakBrickNum;
    private int createItemIndex;
    private float gameStartTime = 0f;
    private float itemCreateTime;

    private void Awake()
    {
        random = new System.Random();
        inventory = GetComponent<ItemInventory>();
        brickManager = brickManager.GetComponent<BrickManager>();
        scoreBoard = brickManager.SetScoreBoardComponent();
    }

    private void Start()
    {
        itemCreateTime = (scoreBoard.SetLevelPlayTime(GameManager.Instance.nowStageNum)/6);
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
                breakBrickNum = brickManager.SetIndex();
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
        itemIndex = random.Next(0, inventory.ApplyItems());

        // GameObject에 저장해뒀던 아이템 생성
        GameObject item = Instantiate(ItemObjects[itemIndex]);

        // 파괴된 벽돌 위치 중 랜덤으로 생성
        while (true)
        {
            createItemIndex = random.Next(0, breakBrickNum);

            if (!brickManager.SetIsCreatedBrick(createItemIndex) && !brickManager.SetIsCreatedItem(createItemIndex))
            {
                break;
            }
        }

        // 랜덤된 위치에 좌표값 가져오기
        Vector2 createItemPosition = brickManager.SetPosition(createItemIndex);

        // 아이템 생성하고 나서 위치값 선택된 랜덤 위치의 좌표값으로 설정
        item.transform.position = new Vector2(createItemPosition.x, createItemPosition.y);

        // 아이템 수치적용
        item.GetComponent<Item>().CreateItem(
        inventory.SetItemStatsName(itemIndex), inventory.SetItemStatsId(itemIndex), inventory.SetItemStatsSpeed(itemIndex),
        inventory.SetItemStatsSize(itemIndex), createItemIndex);

        brickManager.GetIsCreatedItem(createItemIndex, true);
    }
}
