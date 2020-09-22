using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour
{
   
    [SerializeField] Text highScoreTextView;

    private void Start()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        highScoreTextView.text = highScore.ToString();

        
    }
    public void ResetScore()
    {
        PlayerPrefs.SetInt("HighScore", 0);
        highScoreTextView.text = 0.ToString();
    }
    public void GTFO()
    {
        print("You Got Out");
        Application.Quit();
    }
}

