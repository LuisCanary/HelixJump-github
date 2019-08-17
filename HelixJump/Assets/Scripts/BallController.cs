using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private bool ignoreNextCollision;

    private Rigidbody rb;
    [SerializeField]
    private float impulseForce = 5f;

    private Vector3 startPos;

    private void Start()
    {
        startPos = transform.position;
        rb = GetComponent<Rigidbody>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (ignoreNextCollision)        
            return;

        //Death Parts
        DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
        if (deathPart)
        {
            deathPart.HitDeathPart();
        }

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce,ForceMode.Impulse);

        ignoreNextCollision = true;

        Invoke("AllowCollision",0.2f);
    }

    private void AllowCollision()
    {
        ignoreNextCollision = false;
    }

    public void ResetBall()
    {
        transform.position = startPos;
    }

}
