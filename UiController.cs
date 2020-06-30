using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    #region variables
    public bool Red = false;
    public bool Green = false;
    public bool Blue = false;
    public bool Yellow = false;
    public bool Sky = false;
    public bool Purple = false;
    public bool White = false;

    private GamePlay Game;
    private GameEnding End;

    public Text lightColor;
    public float lightTime = 0f;

    public Text ScoreCount;
    public int Score = 0;

    public int YourScore
    {
        get { return Score; }
    }

    public int rand;
    #endregion
    // Start is called before the first frame update
    void Start()
    {
        Game = FindObjectOfType<GamePlay>().GetComponent<GamePlay>();
        End = FindObjectOfType<GameEnding>().GetComponent<GameEnding>();
    }

    // Update is called once per frame
    void Update()
    {
        ScoreCount.text = "" +  Score.ToString();
        #region UI Control
        if (Red == true)
        {
            lightColor.text = "빨강";
            if (Game.RedCount == true && Game.GreenCount == false && Game.BlueCount == false)
            {
                Score++;
            }
        }

        if(Green == true)
        {
            lightColor.text = "초록";
            if (Game.RedCount == false && Game.GreenCount == true && Game.BlueCount == false)
            {
                Score++;
            }
        }

        if(Blue == true)
        {
            lightColor.text = "파랑";
            if (Game.RedCount == false && Game.GreenCount == false && Game.BlueCount == true)
            {
                Score++;
            }
        }

        if(Yellow == true)
        {
            lightColor.text = "노랑";
            if (Game.RedCount == true && Game.GreenCount == true && Game.BlueCount == false)
            {
                Score++;
            }
        }

        if (Sky == true)
        {
            lightColor.text = "청록";
            if (Game.RedCount == false && Game.GreenCount == true && Game.BlueCount == true)
            {
                Score++;
            }
        }

        if (Purple == true)
        {
            lightColor.text = "보라";
            if (Game.RedCount == true && Game.GreenCount == false && Game.BlueCount == true)
            {
                Score++;
            }
        }

        if (White == true)
        {
            lightColor.text = "하양";
            if (Game.RedCount == true && Game.GreenCount == true && Game.BlueCount == true)
            {
                Score++;
            }
        }

        if(End.GameEnd == true)
        {
            lightColor.text = "";
        }

        #endregion
        #region Color Control
        if (Game.gameStart == true)
        {
            lightTime += Time.deltaTime;

            if (lightTime <= 3.0f)
            {
                Green = true;
            }
            else if (lightTime <= 7.0f)
            {
                Green = false;
                White = true;
            }
            else if (lightTime <= 11.0f)
            {
                White = false;
                Blue = true;
            }
            else if (lightTime <= 15.0f)
            {
                Blue = false;
                Red = true;
            }
            else if (lightTime <= 19.0f)
            {
                Red = false;
                Blue = true;
            }
            else if (lightTime <= 23.0f)
            {
               Blue = false;
               Yellow = true;
            }
            else if (lightTime <= 26.0f)
            {
                Yellow = false;
                Sky = true;
            }
            else if (lightTime <= 29.0f)
            {
                Sky = false;
                White = true;
            }
            else if (lightTime <= 32.0f)
            {
                White = false;
                Red = true;
            }
            else if (lightTime <= 35.0f)
            {
                Red = false;
                Blue = true;
            }
            else if (lightTime <= 38.0f)
            {
                Blue = false;
                White = true;
            }
            else if (lightTime <= 41.0f)
            {
                White = false;
                Yellow = true;
            }
            else if (lightTime <= 43.5f)
            {
                Yellow = false;
                Red = true;
            }
            else if (lightTime <= 46.0f)
            {
                Red = false;
                Sky = true;
            }
            else if (lightTime <= 48.0f)
            {
                Sky = false;
                Purple = true;
            }
            else if (lightTime <= 50.0f)
            {
                Purple = false;
                Green = true;
            }
            else if (lightTime <= 52.0f)
            {
                Green = false;
                White = true;
            }
            else if (lightTime <= 54.0f)
            {
                White = false;
                Blue = true;
            }
            else if (lightTime <= 56.0f)
            {
                Blue = false;
                Purple = true;
            }
            else if (lightTime <= 58.0f)
            {
                Purple = false;
                Yellow = true;
            }
            else if (lightTime <= 60.0f)
            {
                Yellow = false;
                Purple = true;
            }
            else if (lightTime <= 62.0f)
            {
                Purple = false;
                Green = true;
            }
            else if (lightTime <= 64.0f)
            {
                Green = false;
                Blue = true;
            }
            else if (lightTime <= 66.0f)
            {
                Blue = false;
                Sky = true;
            }
            else if (lightTime <= 67.5f)
            {
                Sky = false;
                Purple = true;
            }
            else if (lightTime <= 69.0f)
            {
                Purple = false;
                White = true;
            }
            else if (lightTime <= 70.5f)
            {
                White = false;
                Yellow = true;
            }
            else if (lightTime <= 72.0f)
            {
                Yellow = false;
                Red = true;
            }
            else if (lightTime <= 73.5f)
            {
                Red = false;
                Sky = true;
            }
            else if (lightTime <= 75.0f)
            {
                Sky = false;
                Green = true;
            }
            else if (lightTime <= 76.5f)
            {
                Green = false;
                Blue = true;
            }
            else if (lightTime <= 78.0f)
            {
                Blue = false;
                Yellow = true;
            }
            else if (lightTime <= 79.0f)
            {
                Yellow = false;
                Sky = true;
            }
            else if (lightTime <= 80.0f)
            {
                Sky = false;
                End.gameEnd = true;
            }
            #endregion
        }
    }
}
