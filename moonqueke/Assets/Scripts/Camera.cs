using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript2 : MonoBehaviour
{
    public Transform target; // The object you want to orbit around (the Moon).
    public float orbitSpeed = 5.0f; // Adjust this to control the orbit speed.
    public float distance = 10.0f; // Distance from the target (Moon).
    public Vector2 rotationSpeed = new Vector2(5.0f, 2.0f); // Control the horizontal and vertical rotation speed.

    private bool blockMovement = false;
    private float mouseX;
    private float mouseY;

    private void Start()
    {
       // Cursor.lockState = CursorLockMode.Locked; // Lock the mouse cursor to the center of the screen.
       // Cursor.visible = false; // Hide the cursor.
    }

    private void Update()
    {
        if (Input.GetMouseButton(0) && !blockMovement)
        {
            // Get mouse input.
            mouseX += Input.GetAxis("Mouse X") * rotationSpeed.x;
            mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed.y;

            // Limit the vertical rotation to avoid flipping.
            mouseY = Mathf.Clamp(mouseY, -90, 90);

            // Calculate rotation based on mouse input.
            Quaternion rotation = Quaternion.Euler(mouseY, mouseX, 0);

            // Calculate the new camera position based on rotation and distance.
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = rotation * negDistance + target.position;

            // Apply rotation and position to the camera.
            transform.rotation = rotation;
            transform.position = position;
        }
    }

    public void PositionCameraAtLongitudeAndLatitude(float longitude, float latitude, float distanceFromTarget)
    {
        // Clamp latitude to avoid issues with values outside the valid range (-90 to 90 degrees).
        latitude = Mathf.Clamp(latitude, -90f, 90f);

        // Convert longitude and latitude to radians.
        float lonRad = Mathf.Deg2Rad * (longitude+180);
        float latRad = Mathf.Deg2Rad * (latitude);

        // Calculate the position based on spherical coordinates.
        Vector3 position = new Vector3(
            distanceFromTarget * Mathf.Sin(latRad) * Mathf.Cos(lonRad),
            distanceFromTarget * Mathf.Cos(latRad),
            distanceFromTarget * Mathf.Sin(latRad) * Mathf.Sin(lonRad)
        ) + target.position;

        // Set the camera's position.
        transform.position = position;

        // Rotate the camera to look directly down at the target.
        transform.LookAt(target.position);
    }

    public void block()
    {
        this.blockMovement = true;
    }

    public void unlock()
    {
        this.blockMovement = false;
    }
}
