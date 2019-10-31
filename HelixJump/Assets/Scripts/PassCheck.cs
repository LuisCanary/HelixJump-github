using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        GameManager.singleton.AddScore(1);
        FindObjectOfType<BallController>().perfectPass++;
		if (gameObject.name!=("HelixTop"))
		{
			gameObject.SetActive(false);
		}


    }
}
