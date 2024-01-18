using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    [SerializeField]
    float speed = 10.0f;

    void Update()
    {
        transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
}
