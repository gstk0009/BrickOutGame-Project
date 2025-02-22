using UnityEngine;

public class GameController : MonoBehaviour
{
    private int life = 3;

    [SerializeField] private GameObject BossGameClearCanvas;
    [SerializeField] private GameObject GameClearCanvas;
    [SerializeField] private GameObject GameOverCanvas;
    [SerializeField] private GameObject[] LifeUI;

    private void Start()
    {
        GameManager.Instance.gameController = this;
    }

    public void BallDie()
    {
        GameManager.Instance.ballMovement.BallInfoReset();

        life -= 1;

        Invoke("ResetBallPaddle", 2f);
        LifeUI[life].SetActive(false);

        if (life == 0)
        {
            GameOver();
        }
    }

    // BallDie() -> Invoke·Î ¿¬°á
    private void ResetBallPaddle()
    {
        GameManager.Instance.ResetPosition();
    }

    public void GameClear()
    {
        BossGameClearCanvas.SetActive(true);
        AudioManager.Instance.ClearAudio();
        Time.timeScale = 0f;
    }

    public void StageClear()
    {
        GameManager.Instance.maxStageNum = GameManager.Instance.nowStageNum+1;
        GameClearCanvas.SetActive(true);
        AudioManager.Instance.ClearAudio();
        Time.timeScale = 0f;
    }

    public void GameOver()
    {
        GameOverCanvas.SetActive(true);
        AudioManager.Instance.OverAudio();
        Time.timeScale = 0f;
    }
}
