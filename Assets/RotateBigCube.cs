using System.Collections;
using System.Collections.Generic;
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
            transform.Rotate(Vector3.forward, 0f);


            // transform.Rotate(Vector3.right, xRotation * sensitivity);
            // transform.Rotate(Vector3.up, yRotation * sensitivity * -1); 
        } else {
            if (Input.GetKeyDown(KeyCode.R)) {
                FindClosest();
            }

        }


    }

    

    void AlignX() {
        float distance = Quaternion.FromToRotation(transform.eulerAngles, Vector3.right).x;
        transform.Rotate(Vector3.right, distance);
    }

    void FindClosest() {
        Vector3 currentRotation = transform.rotation.eulerAngles;
        Transform cubeTransform = transform; 


        Quaternion targetRotationX = Quaternion.FromToRotation(transform.right, Vector3.right);
        Quaternion targetRotationY = Quaternion.FromToRotation(transform.up, Vector3.right);
        Quaternion targetRotationZ = Quaternion.FromToRotation(transform.forward, Vector3.right);


        Debug.Log("");
        Debug.Log("");
        Debug.Log("================");
        Debug.Log($"Distancia de x para 0: {Quaternion.Angle(transform.rotation, targetRotationX)}"); 
        Debug.Log($"Distancia de y para 0: {Quaternion.Angle(transform.rotation, targetRotationY)}"); 
        Debug.Log($"Distancia de z para 0: {Quaternion.Angle(transform.rotation, targetRotationZ)}"); 
        Debug.Log("================");
        Debug.Log("");
        Debug.Log("");

    }

   

}
