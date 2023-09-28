using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    // private Vector3 rotationAxis = Vector3.up;
    // private float rotationAngle = 90.0f;
    // private float rotationSpeed = 90.0f;
    // private Vector3 pivotPoint;

    // public int axisIndex = 0; 


    // private bool isRotating = false;
    // private Quaternion startRotation;
    // private Quaternion endRotation;

    // private List<RotatePieces> frontFaces = new List<RotatePieces>();
    // private List<RotatePieces> backFaces = new List<RotatePieces>();
    // private List<RotatePieces> topFaces = new List<RotatePieces>();
    // private List<RotatePieces> bottomFaces = new List<RotatePieces>();
    // private List<RotatePieces> leftFaces = new List<RotatePieces>();
    // private List<RotatePieces> rightFaces = new List<RotatePieces>();

    // void Start()
    // {
    //     RotatePieces[] pieces = FindObjectsByType<RotatePieces>(FindObjectsSortMode.None);
    //     MountFaces(pieces);
    // }

    // void Update()
    // {
    //     Rotate();
    // }


    // public void Rotate()
    // {
    //     if (Input.GetKeyDown(KeyCode.R) && !isRotating)
    //     {

    //         Vector3 pivot = new Vector3(-0.416999996f,0,-0.653999984f);

    //         endRotation = Quaternion.AngleAxis(rotationAngle, rotationAxis) * transform.rotation;
    //         pivotPoint = transform.TransformPoint(pivot);
    //         startRotation = transform.rotation;
    //         isRotating = true;

    //         axisIndex = axisIndex == 0 ? 1 : 0; 
    //     }

    //     if (isRotating)
    //     {
    //         float step = rotationSpeed * Time.deltaTime;
    //         transform.rotation = Quaternion.RotateTowards(transform.rotation, endRotation, step);

    //         if (Quaternion.Angle(transform.rotation, endRotation) < 0.01f)
    //         {
    //             transform.rotation = endRotation;
    //             isRotating = false;
    //         }

    //     }
    // }

    // public void MountFaces(RotatePieces[] pieces)
    // {
    //     foreach (var piece in pieces)
    //     {
    //         if (piece.isFront)
    //         {
    //             frontFaces.Add(piece);
    //         }
    //         if (piece.isBack)
    //         {
    //             backFaces.Add(piece);
    //         }
    //         if (piece.isTop)
    //         {
    //             topFaces.Add(piece);
    //         }
    //         if (piece.isBottom)
    //         {
    //             bottomFaces.Add(piece);
    //         }
    //         if (piece.isLeft)
    //         {
    //             leftFaces.Add(piece);
    //         }
    //         if (piece.isRight)
    //         {
    //             rightFaces.Add(piece);
    //         }
    //     }
    // }
}
