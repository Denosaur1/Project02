using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GameObject))]
public class DamageVolume : MonoBehaviour
{
    GameObject damageVolume;
    GameObject HealthSystem;
    HealthBar health;
    float hits;
    public void Awake()
    {
        damageVolume = this.GetComponent<GameObject>();
        HealthSystem = GameObject.Find("HealthSystemController");
        health = HealthSystem.GetComponent<HealthBar>();
        
    }

    private void Update()
    {
        health.HitsTaken= hits;
    }
    private void OnTriggerEnter(Collider other)
    {
        hits++;
    }

}
