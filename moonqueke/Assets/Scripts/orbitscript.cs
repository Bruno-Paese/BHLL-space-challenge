using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class orbitscritp : MonoBehaviour
{
    public Transform centerObject;  // The GameObject to orbit around
    public float orbitSpeed = 1f; // Speed of the orbit in degrees per second
    //public float orbitSpeed = 0.000152f; // Speed of the orbit in degrees per second
    public Vector3 orbitAxis = Vector3.up; // Axis around which to orbit (default is up)

    private void Update()
    {
        // Ensure there's a centerObject assigned
        if (centerObject == null)
        {
            Debug.LogWarning("Center Object is not assigned.");
            return;
        }

        // Calculate the rotation step
        float step = orbitSpeed * Time.deltaTime;

        // Rotate the orbiting GameObject around the centerObject
        transform.RotateAround(centerObject.position, orbitAxis, step);
    }

}
