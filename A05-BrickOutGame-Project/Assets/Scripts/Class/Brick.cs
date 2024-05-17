using UnityEngine;

public class Brick :MonoBehaviour
{
    [SerializeField] private int HP;
    [SerializeField] private int Score;

    private BrickUI brickUI;
    private void Awake()
    {
        brickUI = GetComponent<BrickUI>();
        brickUI.UpdateBrickHPTxt(HP);
    }

    private void GetAttack(int damage)
    {
        HP -= damage;
        if (HP <= 0 )
        {
            HP = 0;
            // TODO ::  AddScore(Score) & 오브젝트풀 끄기
        }
        brickUI.UpdateBrickHPTxt( HP );
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO :: 아이템 등을 사용하여 공의 데미지가 늘어났을 때 수정
        GetAttack(1);
    }
}
