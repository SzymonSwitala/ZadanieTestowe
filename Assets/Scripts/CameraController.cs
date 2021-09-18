using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] private Transform Camera;
    [SerializeField] private float Sensitivity;
    private float xRotation;

 
    void Update()
    {
      
       // Cursor.lockState = CursorLockMode.Confined;
        float MouseX = Input.GetAxis("Mouse X") * Sensitivity * Time.deltaTime;
        float MouseY = Input.GetAxis("Mouse Y") * Sensitivity * Time.deltaTime;

        transform.Rotate(Vector3.up * MouseX);

        xRotation -= MouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        Camera.localRotation = Quaternion.Euler(xRotation, 0, 0);
    }
}