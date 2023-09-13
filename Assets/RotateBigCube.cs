using System;
using System.Collections;
using System.Collections.Generic;
// using System.Numerics;
using UnityEngine;

public class RotateBigCube : MonoBehaviour
{
    // Start is called before the first frame update
    
    float xRotation, yRotation; 
    float sensitivity = 5f;
    bool isRotating = false;
    Vector3 pivot = new Vector3(-0.416999996f,0,-0.653999984f);
    Vector3 rotationAxis = Vector3.right;  


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetMouseButtonDown(0)) {
            isRotating = true; 
        } else if (Input.GetMouseButtonUp(0)) {
            isRotating = false; 
        }

        if (isRotating) {
            xRotation = Input.GetAxis("Mouse Y");
            yRotation = Input.GetAxis("Mouse X");

            transform.RotateAround(pivot, Vector3.right, xRotation * sensitivity);
            transform.RotateAround(pivot, Vector3.up, yRotation * sensitivity * -1);

            // Alternativa CHATGPT: 
            // Quaternion rotation = Quaternion.Euler(xRotation * sensitivity, yRotation * sensitivity * -1, 0f);
            // transform.rotation = rotation * transform.rotation;
 
        } else {
            if (Input.GetKeyDown(KeyCode.R)) {
                FindClosest();
            }

        }


    }



    void FindClosest() {

        float x = Mathf.Abs(Vector3.Dot(transform.right, Vector3.right));
        float y = Mathf.Abs(Vector3.Dot(transform.up, Vector3.right));
        float z = Mathf.Abs(Vector3.Dot(transform.forward, Vector3.right));
        
        float closest; 

        if (x > y && x > z) {
            closest = x; 
        } else if (y > x && y > z) {
            closest = y; 
        } else {
            closest = z; 
        }

        // Debug.Log("=============");
        // Debug.Log("=============");
        // Debug.Log($"Rotation of x: {Mathf.Abs(x)}");
        // Debug.Log($"Rotation of y: {Mathf.Abs(y)}");
        // Debug.Log($"Rotation of z: {Mathf.Abs(z)}");
        // Debug.Log("=============");
        // Debug.Log("=============");
    }

   

}
