using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    public Vector3 rotationVector;
    public void Update()
    {
        transform.Rotate(rotationVector * Time.deltaTime);
    }
}
