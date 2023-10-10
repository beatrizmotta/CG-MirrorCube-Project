using UnityEngine;
using System;
using App;

public class LayerManager: MonoBehaviour {
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Return)) {
            this.RotateCube(LayerMovement.TopClockwise);
        }
    }
    
    public void RotateCube(LayerMovement movement) {
        Layer layer = this.GetLayerByMovement(movement);

        switch(movement) {
            case LayerMovement.TopClockwise: {
                layer.transform.Rotate(Vector3.up, 90f, Space.Self);
                Debug.Log("Rotated");
                break;
            }
        }
    }

    private Layer GetLayerByMovement(LayerMovement movement) {
        LayerIdentifier? identifier = LayerManager.GetLayerIdentifier(movement);
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Layer");

        if (Enum.IsDefined(typeof(LayerIdentifier), identifier)) {
            foreach (GameObject item in objects) {
                Layer layer = item.GetComponent<Layer>();
                if (layer.identifier == identifier) {
                    return layer;
                }
            }
        }

        string message = Messages.getValue("LAYERLESS_MOVEMENT");
        throw new ArgumentException(message, nameof(movement));
    }

    private static LayerIdentifier GetLayerIdentifier(LayerMovement movement) {
        switch(movement) {
            case LayerMovement.TopClockwise or LayerMovement.TopAntiClockwise: return LayerIdentifier.Top;
            case LayerMovement.BackClockwise or LayerMovement.BackAntiClockwise: return LayerIdentifier.Back;
            case LayerMovement.LeftClockwise or LayerMovement.LeftAntiClockwise: return LayerIdentifier.Left;
            case LayerMovement.RightClockwise or LayerMovement.RightAntiClockwise: return LayerIdentifier.Right;
            case LayerMovement.FrontClockwise or LayerMovement.FrontAntiClockwise: return LayerIdentifier.Front;
            case LayerMovement.BottomClockwise or LayerMovement.BottomAntiClockwise: return LayerIdentifier.Bottom;
            default: return (LayerIdentifier) (-1);
        }
    }
}