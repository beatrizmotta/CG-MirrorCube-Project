using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBigCubeBackup : MonoBehaviour
{
    float mousePressPosition, mouseReleasePosition, currentDirection;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        DetectSwipe();

        if (currentDirection < 0) {
            transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
        } else {
            transform.Rotate(new Vector3(0, -90, 0) * Time.deltaTime);
        }

        // if (RightSwipe()) {
        //     transform.Rotate(new Vector3(0, 90, 0));
        // } else if (LeftSwipe()) {
        //     transform.Rotate(new Vector3(0, -90, 0));
        // }

        // transform.Rotate(new Vector3(0, 90, 0) * Time.deltaTime);
        
    }

    void DetectSwipe() {
        if (Input.GetMouseButtonDown(0)) {
            mousePressPosition = Input.mousePosition.x;
        }

        if (Input.GetMouseButtonUp(0)) {
            mouseReleasePosition = Input.mousePosition.x;
            currentDirection = mouseReleasePosition - mousePressPosition;
            
        }

    }
}
