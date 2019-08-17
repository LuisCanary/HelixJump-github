using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private GameObject target;

    private float offset;

    private void Awake()
    {
        target= GameObject.Find("Ball");
        offset = transform.position.y - target.transform.position.y; ;
    }

    private void Update()
    {
        Vector3 currentPos = transform.position;

        currentPos.y = target.transform.position.y + offset;

        transform.position = currentPos;
    }
}
