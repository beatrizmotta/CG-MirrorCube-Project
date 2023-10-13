using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    new Camera camera;

    void Update() {
        if (Input.GetKeyDown(KeyCode.R)) {
            ResetCamera();
        }
    }

    void Start() {
        camera = GameObject.FindObjectOfType<Camera>();
    }

    public void ResetCamera()  {
        camera.GetComponent<CameraRotation>().Reset();
    }


}