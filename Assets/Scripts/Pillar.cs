using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pillar : MonoBehaviour
{
    [SerializeField] Boss BossController;
    [SerializeField] bool IsMain;
    [SerializeField] AudioClip PillarSound;
    [SerializeField] AudioClip CenterOpen;
    public ParticleSystem explode;
    public void PillarHit() {
        if (IsMain == false)
        {
            AudioHelper.PlayClip2D(PillarSound, 1f);
            BossController.bossCounter++;
            this.gameObject.SetActive(false);
            if(BossController.bossCounter == 4)
            {
                AudioHelper.PlayClip2D(CenterOpen, 10f);
            }
        }
        else if(BossController.BossShield == false)
        {
            explode.Play();
            BossController.BossShield = true;
            BossController.bossCounter = 0;
            BossController.phaseNumber++;
            
        }
    }
}
