using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target; // the object to follow
    public float smoothing = 5f; // the smoothing factor for the camera movement

    void LateUpdate()
    {
        // Check if there is a target to follow
        if (target != null)
        {
            // Calculate the new position for the camera
            Vector3 newPosition = target.position;
            newPosition.z = transform.position.z;

            // Smoothly move the camera towards the new position
            transform.position = Vector3.Lerp(transform.position, newPosition, smoothing * Time.deltaTime);
        }
    }
}