using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BallMovement))]
public class PlayerInput : MonoBehaviour
{
    private float horizontalInput = 0f;
    private float verticalInput = 0f;
    private BallMovement ballMovement = null;

    private void Awake()
    {
        ballMovement = GetComponent<BallMovement>();
    }

    void Update()
    {
#if UNITY_ANDROID
        horizontalInput = Input.acceleration.x;
        verticalInput = Input.acceleration.y;
#else 
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
#endif
    }


    private void FixedUpdate()
    {
        ballMovement.Move(new Vector2(horizontalInput, verticalInput));
    }

}
