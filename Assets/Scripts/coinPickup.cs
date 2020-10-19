using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class coinPickup : MonoBehaviour
{
    GameObject levelController; 
    Level01Controller scoreController;
    public AudioClip pickup = null;
    public int scoreValue = 1;
    public void Awake()
    {
        levelController = GameObject.Find("LevelController");
        scoreController = levelController.GetComponent<Level01Controller>();
    }
    private void OnTriggerEnter(Collider other)
    {
        scoreController.IncreaseScore(scoreValue);
        AudioHelper.PlayClip2D(pickup, 1);
        Destroy(this.gameObject);
    }
}
