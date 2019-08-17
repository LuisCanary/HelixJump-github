using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private bool ignoreNextCollision;

    private Rigidbody rb;
    [SerializeField]
    private float impulseForce = 5f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreNextCollision)        
            return;
        
        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce,ForceMode.Impulse);

        ignoreNextCollision = true;

        Invoke("AllowCollision",0.2f);

        GameManager.singleton.AddScore(1);
        
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }


}
