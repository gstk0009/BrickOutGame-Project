using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectStageUI : MonoBehaviour
{
    [SerializeField] List<GameObject> stageBtns = new List<GameObject>();
    [SerializeField] List<GameObject> stageBtnsLockImg = new List<GameObject>();
    private void Start()
    {
        LockBtns();
        UnLockStages();
    }
    private void LockBtns()
    {
        foreach (var button in stageBtns)
        {
            button.GetComponent<Button>().interactable = false;
        }
    }
    private void UnLockStages()
    {
        for (int i = 0; i < GameManager.Instance.maxStageNum; i++)
        {
            UnlockStage(i);
            stageBtnsLockImg[i].SetActive(false);
        }
    }

    private void UnlockStage(int idx)
    {
        stageBtns[idx].GetComponent<Button>().interactable = true;
    }

    public void SetNowStageNum(int i)
    {
        GameManager.Instance.nowStageNum = i;
    }
}
