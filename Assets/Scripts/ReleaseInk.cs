using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReleaseInk : MonoBehaviour
{

    private ParticleSystem inkParticles = null;
    private Vector3 lastInkPosition = Vector3.zero;
    [SerializeField]
    private float distanceBetweenInks = 1f;
    private float currentDistanceFromInk = 0f;
    private int lineSize = 1;
    private int inkQuantity = 100;
    private int currentInkQuantity;
    private int releaseQuantity = 5;
    private float scaleDownFactor;

    private void Awake()
    {
        inkParticles = GetComponent<ParticleSystem>();
        currentInkQuantity = inkQuantity;
        scaleDownFactor = (float)releaseQuantity / (float)inkQuantity / 2f;
    }

    // Update is called once per frame
    void Update()
    {
        currentDistanceFromInk = Vector3.Distance(transform.position, lastInkPosition);
        if (currentDistanceFromInk >= distanceBetweenInks)
        {
            currentDistanceFromInk = 0f;
            lastInkPosition = transform.position;
            ReleaseInkAtCurrentPosition();
            ResizeBall();
        }
    }

    private void ResizeBall()
    {
        transform.localScale = new Vector3(
            transform.localScale.x - scaleDownFactor,
            transform.localScale.y - scaleDownFactor,
            transform.localScale.z
        );
    }

    private void ReleaseInkAtCurrentPosition()
    {
        currentInkQuantity -= releaseQuantity;
        Debug.Log(currentInkQuantity);
        inkParticles.Play();
        if (currentInkQuantity <= 0)
        {
            RemoveBall();
        }
    }

    private void RemoveBall()
    {
        throw new NotImplementedException();
    }
}
