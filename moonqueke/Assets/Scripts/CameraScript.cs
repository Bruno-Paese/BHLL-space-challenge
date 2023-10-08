using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{

    public Transform target; // The object you want to orbit around (the Moon).
    public float orbitSpeed = 2.0f; // Adjust this to control the orbit speed.
    public float distance = 1.0f; // Distance from the target (Moon).
    public Vector2 rotationSpeed = new Vector2(5.0f, 2.0f); // Control the horizontal and vertical rotation speed.

    private Camera mainCam;
    public float zoomSpeed = 5.0f; // Adjust the zoom speed as needed
    public float minFOV = 10.0f; // Minimum FOV
    public float maxFOV = 60.0f; // Maximum FOV

    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {
        mainCam = this.GetComponentInParent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        float zoomInput = Input.GetAxis("Mouse ScrollWheel"); // Get the mouse scroll input
        // Adjust the FOV based on input
        
        mainCam.fieldOfView = Mathf.Clamp(mainCam.fieldOfView - zoomInput * zoomSpeed, minFOV, maxFOV);

        if (Input.GetMouseButton(0))
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
}
