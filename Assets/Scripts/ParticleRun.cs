using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRun : MonoBehaviour
{
    ParticleSystem trail;
    
    [SerializeField] AudioClip sound = null;

    void Start()
    {
        trail = GetComponent<ParticleSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {

            trail.Play();
            AudioHelper.PlayClip2D(sound,1f);
        }
       
    }
}
