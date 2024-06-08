using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieInTime : MonoBehaviour
{
    public float secs;
    void Start()
    {
        Invoke(nameof(Die), secs);
    }
    public void Die()
    {
        Destroy(gameObject);
    }
}
