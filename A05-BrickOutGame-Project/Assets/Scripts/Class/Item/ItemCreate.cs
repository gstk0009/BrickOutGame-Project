using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCreate : MonoBehaviour
{
    [SerializeField] private SpriteRenderer[] itemImages;
    private System.Random random;
    private ItemInventory inventory;
    public Item items;

    private int itemIndex;

    private void Awake()
    {
        random = new System.Random();
        inventory = GetComponent<ItemInventory>();
    }
    private void Start()
    {
        itemIndex = random.Next(0, inventory.ApplyItems());
        items.GetComponent<SpriteRenderer>().sprite = itemImages[itemIndex].sprite;

        // 아이템 생성 조건 - 일정 점수, 일정 시간 이후에 생성
        Instantiate(items).CreateItem(
            inventory.GetItemStatsName(itemIndex), inventory.GetItemStatsId(itemIndex), inventory.GetItemStatsSpeed(itemIndex),
            inventory.GetItemStatsSize(itemIndex));
    }

    public int GetIndexNum()
    {
        return itemIndex;
    }

}
