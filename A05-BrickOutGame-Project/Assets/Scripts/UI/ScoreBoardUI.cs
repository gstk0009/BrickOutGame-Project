using TMPro;
using UnityEngine;

public enum textIndex
{
    LV = 0,
    NowScore,
    PlayTime,
    BestScore
}

public class ScoreBoardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] scoreboard;
    public GameObject endingObj;

    private int nowScore = 0;
    private int bestScore = 0;

    private int lvNum;
    private int min;
    private float lvTime;
    private float sec;

    private bool gameOverCalled;

    private void Awake()
    {
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    private void Start()
    {
        lvNum = GameManager.Instance.nowStageNum;
        lvTime = GameManager.Instance.GetLvTime();
        scoreboard[(int)textIndex.LV].text = lvNum.ToString();
        scoreboard[(int)textIndex.BestScore].text = bestScore.ToString();
        gameOverCalled = false;
    }

    private void Update()
    {
        lvTime -= Time.deltaTime;

        if (lvTime > 0f)
        {
            int totalSeconds = Mathf.RoundToInt(lvTime);
            min = totalSeconds / 60;
            sec = totalSeconds % 60;

            scoreboard[(int)textIndex.PlayTime].text = min.ToString("00") + " : " + sec.ToString("00");
        }
        else if (lvTime <= 0 && !gameOverCalled)
        {
            GameManager.Instance.gameController.GameOver();
            gameOverCalled = true;
        }
    }

    public void GetBrickScore(int score)
    {
        nowScore += score;
        SettingScoreBoard();
    }

    private void SettingScoreBoard()
    {
        scoreboard[(int)textIndex.NowScore].text = nowScore.ToString();

        if (nowScore > bestScore)
        {
            bestScore = nowScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            scoreboard[(int)textIndex.BestScore].text = bestScore.ToString();
        }
    }
}
