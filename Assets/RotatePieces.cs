using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePieces : MonoBehaviour
{
    // Start is called before the first frame update

    Transform myFace;
    string currentFace; 
    public bool isFront, isBack, isRight, isLeft, isTop, isBottom;

    private bool isRotating, hasAligned;


    void Start()
    {
        myFace = GameObject.Find("Front").transform;

    }

    // Update is called once per frame


    void Update()
    {

        // bool Physics.Raycast(Ray ray, out RaycastHit hitInfo, float maxDistance, int layerMask)
        


        if (Input.GetMouseButtonDown(0))
        {
            isRotating = true;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            isRotating = false;
            hasAligned = false;
        }

        Vector3 pivot;
        if (isRotating)
        {
            float xRotation = Input.GetAxis("Mouse X");
            // pivot = myFace.eulerAngles;

            pivot = new Vector3(0, 0, 0);

            if (isFront) {
                transform.RotateAround(pivot, Vector3.forward, xRotation * -1 * 5f);
            }



        } else if (!hasAligned) {
            pivot = myFace.eulerAngles;
             if (isFront) {
            
            float currentZRotation = transform.eulerAngles.z;
            float alignedRotation = NearestStraightMultiple(currentZRotation);

            transform.RotateAround(pivot, Vector3.forward, alignedRotation);

            hasAligned = true; 
        }
        }
    }





    public static float NearestStraightMultiple(float angle) {

        float normalizedAngle; 

        if (angle < 0) { 
            normalizedAngle = -angle % -90f; 
        } else {
            normalizedAngle = angle % 90f; 
        }

        float distanceToPrevious = Mathf.Abs(normalizedAngle - 0);
        float distanceToNext = Mathf.Abs(normalizedAngle - 90);

        if (distanceToNext < distanceToPrevious) {
            return distanceToNext;
        } else {
            return -distanceToPrevious;
        }

    }
}
