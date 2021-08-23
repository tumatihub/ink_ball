using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraFollow : MonoBehaviour
{
    private Camera mainCamera = null;
    [SerializeField]
    private float cameraSmoothFactor = 0.01f;
    [SerializeField]
    private Transform cameraFollowTarget = null;

    private void Awake()
    {
        mainCamera = GetComponent<Camera>();
    }

    void Start()
    {
        
    }

    void Update()
    {
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
}
