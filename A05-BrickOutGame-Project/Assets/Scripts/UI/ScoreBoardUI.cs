using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class ScoreBoardUI : MonoBehaviour
{
    [SerializeField] private TMP_Text[] scoreboard;

    private int lvTxt = 0;
    private int nowScoreTxt = 1;
    private int playTimeTxt = 2;
    private int bestScoreTxt = 3;

    private int nowScore = 0;
    private int bestScore = 0;

    private float[] lvTime = { 60f, 120f, 180f, 240f };
    private int lvNum;
    private int min;
    private float sec;

    private void Awake()
    {
        scoreboard[lvTxt] = scoreboard[lvTxt].GetComponent<TMP_Text>();
        scoreboard[nowScoreTxt] = scoreboard[nowScoreTxt].GetComponent<TMP_Text>();
        scoreboard[playTimeTxt] = scoreboard[playTimeTxt].GetComponent<TMP_Text>();
        scoreboard[bestScoreTxt] = scoreboard[bestScoreTxt].GetComponent<TMP_Text>();
        bestScore = PlayerPrefs.GetInt("BestScore");
    }

    private void Start()
    {
        lvNum = GameManager.Instance.stageNum;
        scoreboard[lvTxt].text = lvNum.ToString();
        scoreboard[bestScoreTxt].text = bestScore.ToString();
    }

    private void Update()
    {
        lvTime[lvNum-1] -= Time.deltaTime;

        if (lvTime[lvNum-1] > 0f)
        {
            min = (int)lvTime[lvNum - 1] / 60;
            sec = lvTime[lvNum - 1] % 60;

            scoreboard[playTimeTxt].text = min.ToString("D1") + "Ка " + sec.ToString("N1") + " УЪ";
        }
        else if (lvTime[lvNum-1] <=0)
        {
            Time.timeScale = 0f;
        }
    }

    public void GetBrickScore(int score)
    {
        nowScore += score;
        SettingScoreBoard();
    }

    private void SettingScoreBoard()
    {
        scoreboard[nowScoreTxt].text = nowScore.ToString();

        if (nowScore > bestScore)
        {
            bestScore = nowScore;
            PlayerPrefs.SetInt("BestScore", bestScore);
            scoreboard[bestScoreTxt].text = bestScore.ToString();
        }
    }

    public float SetLevelPlayTime(int index)
    {
        return lvTime[index - 1];
    }
}
