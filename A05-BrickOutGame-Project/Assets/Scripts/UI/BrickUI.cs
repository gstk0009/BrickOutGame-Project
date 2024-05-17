using TMPro;
using UnityEngine;

public class BrickUI : MonoBehaviour
{
    [SerializeField] private TMP_Text brickHP;

    public void UpdateBrickHPTxt(int HP)
    {
        brickHP.text = HP.ToString();
    } 
}
