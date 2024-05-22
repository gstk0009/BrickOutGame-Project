using System.Collections;
using UnityEngine;

public class ItemApplyManager : MonoBehaviour
{
    public ItemBallApply ballApply;
    private Transform ballTransform;

    private float ApplyItemTime = 5f;
    private float itemSpeed;
    private float itemSize;
    
    private float ballInitSpeed;
    private float ballInitSizex;
    private float ballInitSizey;

    private bool isUseItemSize = false;

    private void Awake()
    {
        ballApply = ballApply.GetComponent<ItemBallApply>();
        ballTransform = ballApply.GetComponent <Transform>();
    }

    // 충돌된 Item Speed 값 Ball에 적용하기
    public float ApplyBallItemSpeed(float speed)
    {
        ballInitSpeed = speed;

        itemSpeed = ballApply.SetItemSpeed();

        StartCoroutine("isUsedItemSpeed", ApplyItemTime);

        return ballInitSpeed * itemSpeed;
    }

    // 충돌된 Item Size 값 Ball에 적용하기
    public void ApplyBallItemSize()
    {
        Transform size = ballTransform;

        ballInitSizex = size.localScale.x;
        ballInitSizey = size.localScale.y;

        itemSize = ballApply.SetItemSize();

        size.localScale = new Vector2(ballInitSizex * itemSize, ballInitSizey * itemSize);

        StartCoroutine("isUsedItemSize", ApplyItemTime);
    }

    // 코루틴 : Ball Speed 관련 Item 유지 시간
    IEnumerator isUsedItemSpeed(float time)
    {
        yield return new WaitForSeconds(time);
        ballApply.GetUseItemSpeed(false, ballInitSpeed);
    }
    // 코루틴 : Ball Size 관련 Item 유지 시간
    IEnumerator isUsedItemSize(float time)
    {
        yield return new WaitForSeconds(time);
        Transform size = ballTransform;

        size.localScale = new Vector2(ballInitSizex, ballInitSizey);

        ballApply.GetIsUseItemSize(isUseItemSize);
    }
}
