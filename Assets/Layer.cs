using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour
{

    public LayerMask pieceMask; 
    List<GameObject> pieces = new List<GameObject>(); 
    private bool isRotating, hasAligned;
    public Vector3 pivot; 

    public bool isHorizontal, isVertical; 


    void Start()
    {

    }

    void Update()
    {

        

        Ray raio = Camera.main.ScreenPointToRay(Input.mousePosition); 
        Debug.DrawRay(raio.origin, raio.direction * 100, Color.red);
        
        RaycastHit impacto; 

        // Check if impacto hits in one of the pieces of the current layer

        if (Physics.Raycast(raio, out impacto, 100, pieceMask)) {

            if (pieces.Contains(impacto.collider.gameObject)) {

            }
            

            if (Input.GetMouseButtonDown(0)) {
                
                Debug.Log($"{impacto.collider.gameObject.name}");
                isRotating = true; 

            } else if (Input.GetMouseButtonUp(0)) {

                isRotating = false;
                hasAligned = false;

            }
            

            if (isRotating) {
                float mouseX = Input.GetAxis("Mouse X");
                float mouseY = Input.GetAxis("Mouse Y");

                
                if (Mathf.Abs(mouseX) > Mathf.Abs(mouseY)) {


                    // Movement is primarily horizontal
                    
                    if (isHorizontal) {

                        foreach (GameObject piece in pieces) {
                            piece.transform.RotateAround(pivot, Vector3.forward, mouseX * -1 * 5f);
                        }


                    }






                } else {                    
                    
                
                    // Movement is primarily vertical

                    foreach (GameObject piece in pieces) {
                            piece.transform.RotateAround(pivot, Vector3.forward, mouseY * -1 * 5f);
                    }


                    // if (isVertical) {
                    //     transform.RotateAround(pivot, Vector3.forward, mouseY * -1 * 5f);
                    // }


                }

            } 
            
            // // else if (!hasAligned) {
            
            // //     float currentZRotation = transform.eulerAngles.z;
            // //     float alignedRotation = NearestStraightMultiple(currentZRotation);

            // //     transform.RotateAround(pivot, Vector3.forward, alignedRotation);

            // //     hasAligned = true; 



            // // // Debug.Log($"{impacto.collider.gameObject.name}");

            // // }


        }

    }


   void OnTriggerEnter(Collider other)
    {


        if (other.tag != "LayerAxis") {
            pieces.Add(other.gameObject);
        }

        



        // if (gameObject.name == "Front-Layer" && other.tag != "LayerAxis") {
        //     pieces.Add(other.gameObject);
        // }
    }


    void OnTriggerExit(Collider other) {
        // pieces.Clear(); 
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
