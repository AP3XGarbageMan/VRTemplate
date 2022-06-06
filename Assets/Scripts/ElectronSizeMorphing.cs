using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectronSizeMorphing : MonoBehaviour
{
    private Vector3 currentOrbSize;
    [SerializeField]
    private Vector3 minOrbSize;
    [SerializeField]
    private Vector3 maxOrbSize;

    private float startTime;
    private int duration = 2;

    private bool shouldGrow = true;

    private void Start()
    {
        startTime = Time.time;
    }

    // shrink and grow
    void Update()
    {
        currentOrbSize = transform.localScale;

        // if orb is b
        if (currentOrbSize.x <= minOrbSize.x)
        {
            shouldGrow = true;
            startTime = Time.time - 0.01f;
        }
        if (currentOrbSize.x >= maxOrbSize.x)
        {
            shouldGrow = false;
            startTime = Time.time - 0.01f;
        }


        if (shouldGrow)
        {
            Grow();
        }
        else
        {
            Shrink();
        }
    }

    private void Shrink()
    {
        var tranSition = (Time.time - startTime) / duration;
        transform.localScale = Vector3.Lerp(maxOrbSize, minOrbSize, tranSition);
    }

    private void Grow()
    {
        var tranSition = (Time.time - startTime) / duration;
        transform.localScale = Vector3.Lerp(minOrbSize, maxOrbSize, tranSition);
    }
}
