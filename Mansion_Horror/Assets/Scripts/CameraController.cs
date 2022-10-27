using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using Input = UnityEngine.Input;

public class CameraController : MonoBehaviour
{
    [SerializeField] private float mouseSens = 500f;
    [SerializeField] private Transform PlayerBody;
    [SerializeField] private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float xAxis = Input.GetAxis("Mouse X") * mouseSens * Time.deltaTime;
        float yAxis = Input.GetAxis("Mouse Y") * mouseSens * Time.deltaTime;

        xRotation -= yAxis;
        //Camera max look angle
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        //Camera Movement itself
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        PlayerBody.Rotate(Vector3.up * xAxis);


    }
}
