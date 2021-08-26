using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Ball : MonoBehaviour
{
    public UnityEvent OnDie;

    public void Die()
    {
        OnDie?.Invoke();
    }
}
