using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Level01Controller : MonoBehaviour
{
    private void Awake()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Health.isDed = false;
    }



    [SerializeField] Text currentScoreTextView;
    [SerializeField] HealthBar Health;

    int currentScore;
    private void Update()
    {
        
        /*
        //Increase Score
        if (Input.GetKeyDown(KeyCode.Q))
        {
            IncreaseScore(5);
        }
        */
       
    }

    public void ExitLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            Debug.Log("New High Score: " + currentScore);
        }

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene("MainMenu");

    }
    public void IncreaseScore(int scoreIncrease)
    {
        currentScore += scoreIncrease;
        currentScoreTextView.text =
            "Score: " + currentScore.ToString();
    }
    public void ResetLevel()
    {
        int highScore = PlayerPrefs.GetInt("HighScore");
        if (currentScore > highScore)
        {
            PlayerPrefs.SetInt("HighScore", currentScore);
            Debug.Log("New High Score: " + currentScore);
        }
        SceneManager.LoadScene("Level01");
        
    }
}
