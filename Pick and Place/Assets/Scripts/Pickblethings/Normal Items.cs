using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalItems : MonoBehaviour
{
    public GameObject objectToPlace; // Prefab to place
    public GameObject markerPrefab;  // Prefab for the marker
    public LayerMask groundLayer;    // LayerMask for the ground

    private GameObject placedObject; // Reference to the placed object
    private GameObject marker;       // Reference to the marker object

    public bool Picked=false;
    void Start()
    {
        // Instantiate the marker and disable it initially
        marker = Instantiate(markerPrefab);
        marker.SetActive(false);
    }

    void Update()
    {
        if (!Picked) return;
        // Handle surface detection and marker placement
        DetectSurface();

        // Handle object placement
        if (Input.GetMouseButtonDown(0) && marker.activeSelf) // Left mouse button click and marker is active
        {
            PlaceObject();
        }

        // Handle object rotation
        if (Input.GetMouseButton(1) && placedObject != null) // Right mouse button hold
        {
           // RotateObject();
        }
    }

    private void DetectSurface()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, Mathf.Infinity, groundLayer))
        {
            // Show and position the marker at the hit point
            marker.SetActive(true);
            Vector3 markerPosition = hit.point;
            markerPosition.y += marker.transform.localScale.y / 2; // Adjust for marker height
            marker.transform.position = markerPosition;
        }
        else
        {
            // Hide the marker if no surface is detected
            marker.SetActive(false);
        }
    }

    private void PlaceObject()
    {
        // Place the object at the marker's position
        Vector3 placementPosition = marker.transform.position;
        placementPosition.y += objectToPlace.transform.localScale.y / 2; // Adjust for object height

        if (placedObject == null)
        {
            placedObject = Instantiate(objectToPlace, placementPosition, Quaternion.identity);
        }
        else
        {
            placedObject.transform.position = placementPosition;
        }
    }

    private void RotateObject()
    {
        float rotationSpeed = 100f;
        float rotationX = Input.GetAxis("Mouse X") * rotationSpeed * Time.deltaTime;
        placedObject.transform.Rotate(Vector3.up, -rotationX);
    }
}