using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject PlanetObject;
    public Vector3 RotationVector;
    private void Update()
    {
        PlanetObject.transform.Rotate(RotationVector * Time.deltaTime);
    }
}
