using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] Boss BossController;
    [SerializeField] bool IsMain;
    
    public void PillarHit() {
        if (IsMain == false)
        {
            BossController.bossCounter++;
            this.gameObject.SetActive(false);
        }
        else if(BossController.BossShield == false)
        {
            BossController.BossShield = true;
            BossController.bossCounter = 0;
            BossController.phaseNumber++;
            
        }
    }
}
