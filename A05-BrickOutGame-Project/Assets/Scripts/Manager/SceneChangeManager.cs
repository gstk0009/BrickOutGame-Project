using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChangeManager : MonoBehaviour
{
   public void GotoGameScene()
    {
        SceneManager.LoadScene("GameScene");
    }
    public void GotoLobbyScene()
    {
        SceneManager.LoadScene("LobbyScene");
    }
}
