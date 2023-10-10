using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using App;

public class Layer : MonoBehaviour
{
    public LayerIdentifier identifier;
    public List<Piece> pieces;
    public Vector3 pivotPoint;
    private bool movementComplete;
    private Collider layerCollider;

    private void Start()
    {
        // Get the Collider component on startup
        layerCollider = GetComponent<Collider>();
    }


    public void OnTriggerExit(Collider collision) { }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.CompareTag("Piece") && !movementComplete)
        {
            Piece piece = collision.gameObject.GetComponent<Piece>();
            this.pieces.Add(piece);
        }


    }

    public void CompleteMovement()
    {
        movementComplete = true;
    }

    // Call this method when a new movement starts
    public void StartMovement()
    {
        movementComplete = false;
    }

    // Detect pieces in contact with the layer using Physics.OverlapBox
    public List<Piece> DetectPiecesInContact()
    {
        // Ensure the layer collider is not a trigger
        layerCollider.isTrigger = false;

        List<Piece> piecesInContact = new List<Piece>();

        // Calculate the center based on the collider's bounds
        Vector3 layerCenter = layerCollider.bounds.center;

        // Use Physics.OverlapBox to detect pieces in contact
        Collider[] colliders = Physics.OverlapBox(layerCenter, layerCollider.bounds.size, Quaternion.identity);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Piece"))
            {
                Piece piece = collider.gameObject.GetComponent<Piece>();
                piecesInContact.Add(piece);
            }
        }

        // Restore the trigger status
        layerCollider.isTrigger = true;

        return piecesInContact;
    }



}