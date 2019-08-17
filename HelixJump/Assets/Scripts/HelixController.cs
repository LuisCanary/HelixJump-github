using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelixController : MonoBehaviour
{

    private Vector2 lastTapPos;
    private Vector3 startRotation;


    private void Awake()
    {
        startRotation = transform.localEulerAngles;
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButton(0))
        {
            Vector2 currentTapPos = Input.mousePosition;

            if (lastTapPos == Vector2.zero)
            {
                lastTapPos = currentTapPos;
            }

            float delta = lastTapPos.x - currentTapPos.x;

            lastTapPos = currentTapPos;

            transform.Rotate(Vector3.up * delta);
        }
        if (Input.GetMouseButtonUp(0))
        {
            lastTapPos = Vector2.zero;
        }

    }
}
