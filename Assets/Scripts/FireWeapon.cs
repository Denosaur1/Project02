using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    [SerializeField] Camera cameraController;
    [SerializeField] Transform rayOrigin;
    [SerializeField] float shootDistance = 10f;
    [SerializeField] GameObject visualFeedback;
    public AudioClip HitSound = null;
    RaycastHit objectHit;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            shoot();
        }
    }
    void shoot()
    {
        Vector3 rayDirection = cameraController.transform.forward;
        Debug.DrawRay(rayOrigin.position, rayDirection * shootDistance, Color.red, 1f);

        if (Physics.Raycast(rayOrigin.position, rayDirection, out objectHit ,shootDistance)) 
        {
            EnemyFrozen enemyShooter = objectHit.transform.gameObject.GetComponent<EnemyFrozen>();

            if (objectHit.transform.name == "Pillar")
            {
                Pillar pillar = objectHit.transform.gameObject.GetComponent<Pillar>();
                if (pillar != null)
                {
                    pillar.PillarHit();
                }
            }
            if (objectHit.transform.name == "EnemyViuals")
            {
                Debug.Log("Enemy Hit");
                visualFeedback.transform.position = objectHit.point;
                AudioHelper.PlayClip2D(HitSound, 1f);
            }
            else { Debug.Log("You HIT the " + objectHit.transform.name);
                visualFeedback.transform.position = objectHit.point;
            }
            if(enemyShooter != null){
                enemyShooter.EnemyHit();
            
            }
        }
        else
        {
            Debug.Log("MISS!");
        }
    }
}
