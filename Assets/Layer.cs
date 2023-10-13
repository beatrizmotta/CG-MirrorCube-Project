using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using App;

public class Layer : MonoBehaviour {
    public LayerIdentifier identifier;
    private Collider layerCollider;
    private bool movementComplete;
    public List<Piece> pieces;
    public Vector3 pivotPoint;

    private void Start() {
        layerCollider = GetComponent<Collider>();
    }

    public void OnTriggerEnter(Collider collision) {
        if (collision.CompareTag("Piece") && !movementComplete) {
            Piece piece = collision.gameObject.GetComponent<Piece>();
            this.pieces.Add(piece);
        }
    }

    public void CompleteMovement() {
        this.movementComplete = true;
    }

    public void StartMovement() {
        this.movementComplete = false;
    }

    public List<Piece> DetectPiecesInContact() {
        List<Piece> piecesInContact = new List<Piece>();
        this.layerCollider.isTrigger = false;

        Vector3 layerCenter = layerCollider.bounds.center;
        
        Collider[] colliders = Physics.OverlapBox(layerCenter, layerCollider.bounds.size, Quaternion.identity);

        foreach (Collider collider in colliders) {
            if (collider.CompareTag("Piece")) {
                Piece piece = collider.gameObject.GetComponent<Piece>();
                piecesInContact.Add(piece);
            }
        }

        this.layerCollider.isTrigger = true;

        return piecesInContact;
    }



}