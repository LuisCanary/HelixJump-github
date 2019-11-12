﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PassCheck : MonoBehaviour
{

	string name="Ball";

	List<GameObject> children = new List<GameObject>();

	void Start()
	{
		foreach (Transform t in transform)
		{
			children.Add(t.gameObject);
			
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (name==other.gameObject.name)
		{

		
		foreach (var children in children)
		{
			

			if (gameObject.name != ("HelixTop"))
			{
				children.GetComponent<Animation>().Play("Helix");
				StartCoroutine(WaitToDestroy(children));				
			}
		}

		GameManager.singleton.AddScore(1);
		FindObjectOfType<BallController>().perfectPass++;

		}

	}

	IEnumerator WaitToDestroy(GameObject children)
	{
		yield return new WaitForSeconds(2);
		children.SetActive(false);
	}
}
