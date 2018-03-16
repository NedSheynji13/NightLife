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
        CameraMove();
    }

    void CameraMove()
    {
        Vector3 Pos = transform.position;
        Pos.x += Input.GetAxis("Horizontal") * (sensitivity / 2) * Time.deltaTime;
        Pos.y = 20;
        Pos.z += Input.GetAxis("Vertical") * (sensitivity / 2) * Time.deltaTime;

        transform.position = Pos;
    }

    void CameraZoom()
    {
        FoV += Input.GetAxis("Mouse ScrollWheel") * (sensitivity / 2);
        FoV = Mathf.Clamp(FoV, -40, 0);
        Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, new Vector3(0, 0, FoV), Time.deltaTime * 20);
    }
}