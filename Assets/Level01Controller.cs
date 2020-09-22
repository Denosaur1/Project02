using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    [SerializeField] Text currentScoreTextView;
    [SerializeField] GameObject PauseMenu;
    int currentScore;
    private void Update()
    {
        //Increase Score
        if (Input.GetKeyDown(KeyCode.S))
        {
            IncreaseScore(5);
        }

        //Exit Level
        if (Input.GetKeyDown(KeyCode.Escape))
        {

            bool x = !PauseMenu.activeSelf;
            PauseMenu.SetActive(x);
            //ExitLevel();
        }
    }

    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            Debug.Log("New High Score: " + currentScore);
        }


        SceneManager.LoadScene("MainMenu");

    }
    public void IncreaseScore(int scoreIncrease)
    {
        currentScore += scoreIncrease;
        currentScoreTextView.text =
            "Score: " + currentScore.ToString();
    }
}
