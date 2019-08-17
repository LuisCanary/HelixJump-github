using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private bool ignoreNextCollision;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up,ForceMode.Impulse);
    }


}
