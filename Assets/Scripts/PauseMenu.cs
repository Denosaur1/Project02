using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    [SerializeField] GameObject pauseMenu;
    [SerializeField] GameObject character;
    [SerializeField] HealthBar Health;
    // Update is called once per frame
    void Update()
    {

        if (Health.isDed == true)
            return;
        
          bool Paused = pauseMenu.activeSelf;


        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (Paused)
            {
                
                Resume();
            }
            else
            {
                Pause();
            }
           
        }
    }

    public void Resume() 
    {
        pauseMenu.SetActive(false);
        character.SetActive(true);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    public void Pause()
    {
        pauseMenu.SetActive(true);
        character.SetActive(false);
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }
    
}
