using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Updraft : MonoBehaviour
{
    [SerializeField] float updraftForce = 150f;
    private void OnTriggerEnter(Collider other)
    {
        Rigidbody rbody = other.attachedRigidbody;
        rbody.AddForce(Vector3.up * updraftForce);
    }
}
