using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleRun : MonoBehaviour
{
    ParticleSystem trail;

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

        }
        /*
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {


            trail.Stop();
        }
        */
    }
}
