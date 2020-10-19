using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float bossCounter;
    public int phaseNumber = 1;
    public bool BossShield = true;
    [SerializeField] GameObject PillarPhase1;
    [SerializeField] GameObject PillarPhase2;
    [SerializeField] GameObject PillarPhase3;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject character;
    private void Update()
    {
        if(phaseNumber == 1)
        {
            if( bossCounter == 4)
            {
                Debug.Log("The Center Is open!");
                BossShield = false;
            }
            
        }
        if (phaseNumber == 2)
        {
            PillarPhase1.SetActive(false);
            PillarPhase2.SetActive(true);
            if (bossCounter == 4)
            {
                Debug.Log("The Center Is open!");
                BossShield = false;
            }

        }
        if (phaseNumber == 3)
        {
            PillarPhase2.SetActive(false);
            PillarPhase3.SetActive(true);
            if (bossCounter == 4)
            {
                Debug.Log("The Center Is open!");
                BossShield = false;
            }

        }
        if(phaseNumber == 4)
        {
            Debug.Log("Boss is defeated");
            WinScreen.SetActive(true);
            character.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }

    }


}
