using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] Collider Character;
    GameObject damageVolume;
    GameObject HealthSystem;
    HealthBar health;
    public AudioClip damage= null;
    float damageValue = 1;
    public void Awake()
    {
        damageVolume = this.GetComponent<GameObject>();
        HealthSystem = GameObject.Find("HealthSystemController");
        health = HealthSystem.GetComponent<HealthBar>();

    }

    private void Update()
    {
        //health.HitsTaken = hits;
    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other == Character)
        {
            Debug.Log("Player Hit");
            AudioHelper.PlayClip2D(damage, 1f);
            health.HitsTaken += damageValue;
            Destroy(this.gameObject);

        }
        
    }
}
