using UnityEngine;
using System;
using App;
using System.Collections.Generic;

public class LayerManager : MonoBehaviour
{
    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            this.RotateLayer(LayerMovement.TopClockwise);
        }
    }

    public void RotateLayer(LayerMovement movement)
    {
        Layer layer = this.GetLayerByMovement(movement);

        // Start the movement by setting movementComplete to false
        layer.StartMovement();

        switch (movement)
        {
            case LayerMovement.FrontClockwise:
            {
                foreach (Piece piece in layer.pieces)
                {
                    piece.transform.RotateAround(layer.pivotPoint, Vector3.forward, 90);
                    // piece.transform.Rotate(Vector3.up, 90f, Space.Self);
                }

                // After movement, mark it as complete
                layer.CompleteMovement();

                // Detect pieces in contact with the layer and update the pieces list
                List<Piece> piecesInContact = layer.DetectPiecesInContact();
                foreach(Piece piece in piecesInContact) {
                    print(piece);
                }
                layer.pieces.Clear();
                layer.pieces.AddRange(piecesInContact);

                break;
            }
            case LayerMovement.RightClockwise:
            {
                foreach (Piece piece in layer.pieces)
                {
                    piece.transform.RotateAround(layer.pivotPoint, Vector3.right, 90);
                    // piece.transform.Rotate(Vector3.up, 90f, Space.Self);
                }

                // After movement, mark it as complete
                layer.CompleteMovement();

                // Detect pieces in contact with the layer and update the pieces list
                List<Piece> piecesInContact = layer.DetectPiecesInContact();
                foreach(Piece piece in piecesInContact) {
                    print(piece);
                }
                layer.pieces.Clear();
                layer.pieces.AddRange(piecesInContact);

                break;
            }
        }
    }

    private Layer GetLayerByMovement(LayerMovement movement)
    {
        LayerIdentifier? identifier = LayerManager.GetLayerIdentifier(movement);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Layer");

        if (Enum.IsDefined(typeof(LayerIdentifier), identifier))
        {
            foreach (GameObject item in objects)
            {
                Layer layer = item.GetComponent<Layer>();
                if (layer.identifier == identifier)
                {
                    return layer;
                }
            }
        }

        string message = Messages.getValue("LAYERLESS_MOVEMENT");
        throw new ArgumentException(message, nameof(movement));
    }

    private static LayerIdentifier GetLayerIdentifier(LayerMovement movement)
    {
        switch (movement)
        {
            case LayerMovement.TopClockwise or LayerMovement.TopAntiClockwise: return LayerIdentifier.Top;
            case LayerMovement.BackClockwise or LayerMovement.BackAntiClockwise: return LayerIdentifier.Back;
            case LayerMovement.LeftClockwise or LayerMovement.LeftAntiClockwise: return LayerIdentifier.Left;
            case LayerMovement.RightClockwise or LayerMovement.RightAntiClockwise: return LayerIdentifier.Right;
            case LayerMovement.FrontClockwise or LayerMovement.FrontAntiClockwise: return LayerIdentifier.Front;
            case LayerMovement.BottomClockwise or LayerMovement.BottomAntiClockwise: return LayerIdentifier.Bottom;
            default: return (LayerIdentifier)(-1);
        }
    }
}
