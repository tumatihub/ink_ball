using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class PlayerInput : MonoBehaviour
{
    
    private Camera mainCamera = null;
    private float horizontalInput = 0f;

    [SerializeField]
    public float rotationSpeed = 5f;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Start()
    {
        
    }

    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void FixedUpdate()
    {
        RotateGravity();
        RotateCamera();
    }

    private void RotateGravity()
    {
        Physics2D.gravity = Quaternion.Euler(0, 0, horizontalInput * Time.fixedDeltaTime * rotationSpeed) * Physics2D.gravity;
        Debug.Log(Physics2D.gravity.magnitude);
    }

    private void RotateCamera()
    {
        Vector3 gravityDir = Physics2D.gravity.normalized;
        mainCamera.transform.up = -gravityDir;
    }

    private void OnDrawGizmos()
    {
        Vector3 gravityDir = Physics2D.gravity.normalized;
        Gizmos.DrawLine(Vector3.zero, Vector3.zero + (gravityDir * 10));
    }
}
