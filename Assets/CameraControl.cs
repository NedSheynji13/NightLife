using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    public float sensitivity;
    private float FoV;
    private Vector3 inputAngle, cameraZoom;

    void Start()
    {
        inputAngle = new Vector3(45, 0, 0);
        cameraZoom = transform.GetChild(0).position;
        FoV = cameraZoom.z;
    }

    void LateUpdate()
    {
        CameraZoom();
        CameraTurn();
        CameraMove();
    }

    void CameraTurn()
    {
        inputAngle.y += Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        inputAngle.x -= Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        if (inputAngle.y > 360)
            inputAngle.y -= 360;
        else if (inputAngle.y < 0)
            inputAngle.y += 360;

        inputAngle.x = Mathf.Clamp(inputAngle.x, 30, 60);
        transform.localRotation = Quaternion.Euler(inputAngle);
    }

    void CameraMove()
    {
        Vector3 Pos = transform.position;
        Pos.x += Input.GetAxis("Horizontal") * (sensitivity / 2) * Time.deltaTime;
        Pos.y = 20;
        Pos.z += Input.GetAxis("Vertical") * (sensitivity / 2) * Time.deltaTime;

        Pos = Quaternion.Euler(0, transform.rotation.eulerAngles.y, 0) * Pos;
        transform.position = Pos;
    }

    void CameraZoom()
    {
        FoV += Input.GetAxis("Mouse ScrollWheel") * (sensitivity / 2);
        FoV = Mathf.Clamp(FoV, -40, 0);
        Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, new Vector3(0, 0, FoV), Time.deltaTime * 20);
    }
}