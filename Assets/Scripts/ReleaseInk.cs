using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Ball))]
public class ReleaseInk : MonoBehaviour
{

    private Ball ball;
    private ParticleSystem inkParticles = null;
    private Vector3 lastInkPosition = Vector3.zero;
    [SerializeField]
    private float distanceBetweenInks = 1f;
    private float currentDistanceFromInk = 0f;
    private int lineSize = 1;
    private int inkQuantity = 100;
    private int currentInkQuantity;
    [SerializeField]
    private int releaseQuantity = 5;
    private float scaleDownFactor;

    public UnityEvent OnReleaseAllInk;

    private void Awake()
    {
        ball = GetComponent<Ball>();
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("InkRefill"))
        {
            Refill();
        }
    }

    private void Refill()
    {
        currentInkQuantity = inkQuantity;
        FullSizeBall();
    }

    private void FullSizeBall()
    {
        transform.localScale = Vector3.one;
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
        currentInkQuantity = Mathf.Max(currentInkQuantity - releaseQuantity, 0);
        inkParticles.Play();
        if (currentInkQuantity <= 0)
        {
            OnReleaseAllInk?.Invoke();
            RemoveBall();
        }
    }

    private void RemoveBall()
    {
        ball.Die();
    }
}
