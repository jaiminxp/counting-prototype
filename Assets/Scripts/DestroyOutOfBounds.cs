using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    float xBound = 17.0f;
    float topBound = 11.0f;

    void Update()
    {
        bool isOutOfBounds = transform.position.x > xBound || transform.position.x < -xBound || transform.position.y > topBound;

        if (isOutOfBounds)
        {
            Destroy(gameObject);
        }
    }
}
