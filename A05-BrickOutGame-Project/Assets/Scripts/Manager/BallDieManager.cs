using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallDieManager : MonoBehaviour
{
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 9)
        {
            GameManager.Instance.gameController.BallDie();
        }
    }
}
