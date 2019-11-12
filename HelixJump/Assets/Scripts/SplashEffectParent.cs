using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashEffectParent : MonoBehaviour
{
    
    void Start()
    {
		Invoke("DestroyObject",1f);
    }


	public void DestroyObject()
	{
		Destroy(gameObject);
	}

    
}
