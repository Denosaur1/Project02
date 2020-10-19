using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField] GameObject EnemyVisuals;
    [SerializeField] GameObject FrozenVisuals;
    [SerializeField] Rigidbody ball;
    public float shootSpeed = 500f;
    public bool PlayerDetected = false;
    public float time;
    public AudioClip HitSound = null;
    [SerializeField] Collider pCollider;
    bool enemyFrozen = false;
    public float freezeTime = 0;
    // Update is called once per frame
    private void Awake()
    {
        PlayerDetected = false;

    }
    private void OnTriggerEnter(Collider other)
    {
        
        if (other == pCollider && enemyFrozen == false)
        {
            time = 0;
            PlayerDetected = true;
        }
        //curTimer = shootTimer;
        //this.transform.LookAt(Player.transform);
    }
    private void OnTriggerExit(Collider Player)
    {
        PlayerDetected = false;

    }
    private void Update()
    {
        if (PlayerDetected == true && enemyFrozen == false)
        {
            EnemyVisuals.transform.LookAt(Player.transform);
        }
        TimerStart();
        if(enemyFrozen)
        {
            FrozenTimer();
        }
    }

    void TimerStart()
    {
        time += Time.deltaTime;
        if (time >= 3)
        {
            time = 0;
            if (PlayerDetected == true && enemyFrozen == false)
            {
                EnemyShoot();
            }
        }
    }

    private void EnemyShoot()
    {
        var Shoot = Instantiate(ball, EnemyVisuals.transform.position, EnemyVisuals.transform.rotation);
        Shoot.AddForce(EnemyVisuals.transform.forward * shootSpeed);
        Destroy(Shoot.gameObject, 2);

    }

    public void EnemyFreeze(){
        enemyFrozen = true;
        FrozenVisuals.SetActive(true);
        AudioHelper.PlayClip2D(HitSound, 1f);



    }
    void FrozenTimer()
    {
        freezeTime += Time.deltaTime;
        if (freezeTime > 10f)
        {
            freezeTime = 0;
            enemyFrozen = false;
            FrozenVisuals.SetActive(false);
            Debug.Log("Unfrozen");
        }

    }
}
