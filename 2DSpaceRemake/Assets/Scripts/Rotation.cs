using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotation : MonoBehaviour
{
    public float rotationSpeed = 50;
    public Vector3 rotationDirection;
    void Update()
    {
        transform.Rotate(rotationDirection, rotationSpeed * Time.deltaTime);
    }
}
