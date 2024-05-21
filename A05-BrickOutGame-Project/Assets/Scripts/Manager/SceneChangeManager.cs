using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
    public void GotoNextGame()
    {
        GameManager.Instance.stageNum += 1;
        SceneManager.LoadScene("GameScene");
    }
   public void GotoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GotoLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
