// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class CubeRotation : MonoBehaviour
// {

//     public Transform Cube;
//     public float radius = 9; 
 
//     float sensitivity = 5; 
//     // Start is called before the first frame update
//     void Start()
//     {
//         transform.position = Cube.position - (transform.forward * radius);
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if (Input.GetMouseButton(1)) {
//             Rotate(); 
//         }
        
//     }

//     void Rotate() {
//         transform.RotateAround(Cube.position, Vector3.up, Input.GetAxis("Mouse X") * sensitivity);
//         transform.RotateAround(Cube.position, transform.right, Input.GetAxis("Mouse Y") * sensitivity * -1);
//     }
// }
