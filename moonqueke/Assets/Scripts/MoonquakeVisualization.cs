using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonquakeVisualization : MonoBehaviour
{
    public GameObject template; // Assign the GameObject prefab you want to place here.
    public float latitude = 0.0f; // Latitude in degrees (-90 to 90).
    public float longitude = 0.0f; // Longitude in degrees (-180 to 180).
    public float hoverHeight = 0.000000000000000000000001f; // Height above the surface.
    public List<MoonQuakeModel> moonQuakes = new List<MoonQuakeModel>();

    private int index = 0, max = 200;
    private GameObject gameObjects;

    void Start()
    {
        //CreateMarker(longitude, latitude, "");
    }

    void Update()
    {
        
    }

    public void deleteMarker()
    {
        if (gameObjects != null)
        {
            GameObject.Destroy(gameObjects);
            gameObjects = null;
        }
    }
    public Transform CreateMarker(float lat, float lon, string name)
    {
        if (gameObjects != null)
        {
            GameObject.Destroy(gameObjects);
            gameObjects = null;
        }

        // Check if the template is assigned.
        if (template != null)
        {
            // Calculate the position on the sphere's surface based on latitude and longitude.
            Vector3 position = CalculatePositionOnSphere(lat, lon - 180);

            // Calculate the normal vector at the point on the sphere's surface.
            Vector3 normal = (position - transform.position).normalized;

            // Calculate the rotation to align the object with the normal vector.
            Quaternion rotation = Quaternion.FromToRotation(Vector3.up, normal);

            // Apply an additional rotation of 90 degrees around the normal vector to orient the object correctly.
            Quaternion additionalRotation = Quaternion.Euler(90.0f, 0.0f, 0.0f);
            rotation *= additionalRotation;

            // Calculate the final position with a slight offset above the surface.
            Vector3 finalPosition = position + (normal * 0.01f);

            // Instantiate the template at the calculated position with the rotation.
            gameObjects = Instantiate(template, finalPosition, rotation);
            gameObjects.transform.SetParent(transform, true);

            gameObjects.transform.localScale = new Vector3(0.02f, 0.02f, 0.02f);
            return gameObjects.transform;
        }
        return null;
    }

    Vector3 CalculatePositionOnSphere(float lat, float lon)
    {
        // Convert latitude and longitude to radians.
        float latRad = Mathf.Deg2Rad * lat;
        float lonRad = Mathf.Deg2Rad * lon;

        // Calculate the position on the sphere's surface.
        float radius = transform.localScale.x * 0.5f; // Assuming the sphere's scale is uniform.
        float x = radius * Mathf.Cos(latRad) * Mathf.Cos(lonRad);
        float y = radius * Mathf.Sin(latRad);
        float z = radius * Mathf.Cos(latRad) * Mathf.Sin(lonRad);

        return new Vector3(x, y, z) + transform.position;
    }
}
