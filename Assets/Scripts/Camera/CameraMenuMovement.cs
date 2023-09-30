using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenuMovement : MonoBehaviour
{
    [SerializeField] private float speed;

    private void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);
    }
}
