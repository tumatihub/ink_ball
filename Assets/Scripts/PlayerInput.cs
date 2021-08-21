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
    [SerializeField]
    public float cameraSmoothFactor = 0.01f;
    [SerializeField]
    public Transform cameraFollowTarget = null;

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
        RotateCamera();
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 newCamerPos = new Vector3(
            cameraFollowTarget.transform.position.x,
            cameraFollowTarget.transform.position.y,
            transform.position.z
        );
        float distance = Vector3.Distance(newCamerPos, transform.position);
        
        transform.position = Vector3.Lerp(transform.position, newCamerPos, Mathf.Min(distance * cameraSmoothFactor, 1f));
    }

    private void FixedUpdate()
    {
        RotateGravity();
        
    }

    private void RotateGravity()
    {
        Physics2D.gravity = Quaternion.Euler(0, 0, horizontalInput * Time.fixedDeltaTime * rotationSpeed) * Physics2D.gravity;
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
