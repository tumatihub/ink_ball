using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Rotate : MonoBehaviour
{
    private Rigidbody2D rb = null;
    [SerializeField]
    private float rotationSpeed = 5f;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        rb.MoveRotation(rb.rotation + Time.fixedDeltaTime * rotationSpeed);
    }
}
