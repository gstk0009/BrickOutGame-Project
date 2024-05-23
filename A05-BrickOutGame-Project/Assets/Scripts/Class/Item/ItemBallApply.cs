using UnityEngine;


public class ItemBallApply : MonoBehaviour
{
    public ItemApplyManager applyManager;
    private EndingManager endingManager;
    private Item item;
    private BallMovement ballMovement;
    [SerializeField] private BrickManager brickManager;

    private int itemId = 0;
    private int itemCreatedIndex = 0;
    private bool isUseItemSpeed = false;
    private bool isUseItemSize = false;

    private void Awake()
    {
        ballMovement = GetComponent<BallMovement>();
        endingManager = GetComponent<EndingManager>();
        applyManager = applyManager.GetComponent<ItemApplyManager>();
        brickManager = brickManager.GetComponent<BrickManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            item = collision.GetComponent<Item>();
            itemId = item.Id;
            itemCreatedIndex = item.CreateIndex;

            if (itemId >= 1 && itemId <= 1000)
            {
                if ((itemId == 1 || itemId == 2) && !isUseItemSize)
                {
                    isUseItemSize = true;
                    applyManager.ApplyBallItemSize();
                }
                else if ((itemId == 3 || itemId == 4) && !isUseItemSpeed)
                {
                    isUseItemSpeed = true;
                    ballMovement.GetBallSpeed(applyManager.ApplyBallItemSpeed(ballMovement.SetBallSpeed()));
                }
                brickManager.GetIsCreatedItem(itemCreatedIndex, false);
                Destroy(collision.gameObject);
            }
        }
    }

    public void GetUseItemSpeed(bool isuseItem, float initSpeed)
    {
        isUseItemSpeed = isuseItem;

        ballMovement.GetBallSpeed(initSpeed);
    }

    public void GetIsUseItemSize(bool isUseItem)
    {
        isUseItemSize = isUseItem;
    }

    public float SetItemSpeed()
    {
        return item.Speed;
    }

    public float SetItemSize()
    {
        return item.Size;
    }

    public bool SetIsUseItemSpeed()
    {
        return isUseItemSpeed;
    }

    public bool SetIsUseItemSize()
    {
        return isUseItemSize;
    }
}
