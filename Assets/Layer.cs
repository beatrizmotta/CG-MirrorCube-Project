using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using App;

public class Layer: MonoBehaviour {
    public LayerIdentifier identifier;
    public List<Piece> pieces;

    public void OnTriggerExit(Collider collision) {}
    
    public void OnTriggerEnter(Collider collision) {
        if (collision.gameObject.tag == "Piece") {
            Piece piece = collision.gameObject.GetComponent<Piece>();
            this.pieces.Add(piece);
        }
    }
}