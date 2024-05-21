using System.Collections;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
    [SerializeField] private GameObject BlindSkillCanvas;
    private bool canCreateShield = false;

    // 3초간 플레이어 화면 가리기
    public void BlindSkill()
    {
        StartCoroutine("BlindTime", 5f);
    }

    public void ShieldSkill()
    {

    }

    public void CanCreateShield()
    {
        canCreateShield = true;
    }

    IEnumerator BlindTime(float time)
    {
        BlindSkillCanvas.SetActive(true);
        yield return new WaitForSeconds(time);
        BlindSkillCanvas.SetActive(false);
    }
}