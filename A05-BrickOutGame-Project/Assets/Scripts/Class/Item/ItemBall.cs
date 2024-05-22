public class ItemBall : Item
{
    private ItemBall itemBall;

    protected override void Awake()
    {
        base.Awake();
        SetItemBall();
    }

    private void Start()
    {
    }

    private void SetItemBall()
    {
        SetItem("BallSizeUp", 1, 0f, 1.5f);
        SetItem("BallSizeDown", 2, 0f, 0.8f);
        SetItem("BallSpeedUp", 3, 1.5f, 0f);
        SetItem("BallSpeedDown", 4, 0.8f, 0f);
    }
}
