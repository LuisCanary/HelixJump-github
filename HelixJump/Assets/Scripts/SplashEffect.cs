using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffect : MonoBehaviour
{
	Rigidbody rigid;
    void Start()
    {
		rigid = GetComponent<Rigidbody>();
		rigid.AddForce(new Vector3(Random.Range(-2,2), Random.Range(-2, 2), Random.Range(-2,2)),ForceMode.Impulse);
		Invoke("AddGravity",0.5f);
	}

	public void AddGravity()
	{
		rigid.GetComponent<Rigidbody>().useGravity=true;
		
	}

}
