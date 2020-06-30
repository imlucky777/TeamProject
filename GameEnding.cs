using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameEnding : MonoBehaviour
{
    public bool GameEnd = false;

    public bool gameEnd
    {
        set { GameEnd = value; }
    }

    private UiController Ui;
    private GamePlay Game;

    public GameObject Panel;
    public Text now_Score;
    public Text best_Score;

    public int bestScore;

    // Start is called before the first frame update
    void Start()
    {
        Game = FindObjectOfType<GamePlay>().GetComponent<GamePlay>();
        Ui = FindObjectOfType<UiController>().GetComponent<UiController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Ui.Score > bestScore)
        {
            bestScore = Ui.Score;
        }

        now_Score.text = "당신의 스코어:" + Ui.Score.ToString();
        best_Score.text = "최고 스코어:" + bestScore.ToString();
  

        if (GameEnd == true)
        {
            Panel.SetActive(true);
        }
        else
        {
            Panel.SetActive(false);
        }
    }

    public void reset()
    {
        #region initialization

        GameEnd = false;
        Game.GameStart = false;
        Game.ThemeSound.Stop();

        Ui.Score = 0;

        Ui.lightTime = 0;
        Game.timeCost = 0;

        Ui.Blue = false;
        Ui.Red = false;
        Ui.Green = false;
        Ui.White = false;
        Ui.Yellow = false;
        Ui.Purple = false;
        Ui.Sky = false;

        #endregion
    }

    void pause()
    {

    }
}
