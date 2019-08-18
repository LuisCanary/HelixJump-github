using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    private bool ignoreNextCollision;

    private Rigidbody rb;
    [SerializeField]
    private float impulseForce = 5f;
    [HideInInspector]
    public int perfectPass;
    [SerializeField]
    private bool isSuperSpeedActive;
    [SerializeField]
    private float superSpeed = 10f;

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

        if (isSuperSpeedActive && !collision.transform.GetComponent<Goal>())
        {
             Destroy(collision.transform.parent.gameObject,0.2f);
        }
        else
        {
            //Death Parts
            DeathPart deathPart = collision.transform.GetComponent<DeathPart>();
            if (deathPart)
            {
                deathPart.HitDeathPart();
            }
        }

        

        rb.velocity = Vector3.zero;
        rb.AddForce(Vector3.up * impulseForce,ForceMode.Impulse);

        ignoreNextCollision = true;

        Invoke("AllowCollision",0.2f);

        perfectPass = 0;
        isSuperSpeedActive = false;
    }


    private void Update()
    {
        if (perfectPass>=3 && !isSuperSpeedActive)
        {
            isSuperSpeedActive = true;
            rb.AddForce(Vector3.down*superSpeed,ForceMode.Impulse);
        }
          
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
