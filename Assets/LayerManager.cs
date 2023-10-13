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

    public void RotateLayer(LayerMovement movement) {
        Layer layer = this.GetLayerByMovement(movement);
        Vector3 layerPosition = layer.transform.position;
        layer.StartMovement();

        switch (movement) {
            case LayerMovement.FrontClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.z < layerPosition.z) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.forward, 90);
                    }
                }

                break;
            }
            case LayerMovement.FrontAntiClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.z < layerPosition.z) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.forward, -90);
                    }
                }

                break;
            }
            case LayerMovement.RightClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.x > layerPosition.x) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.right, 90);
                    }
                }

                break;
            }
            case LayerMovement.LeftClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.x < layerPosition.x) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.right, 90);
                    }
                }

                break;
            }
            case LayerMovement.TopClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.y > layerPosition.y) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.up, 90);
                    }
                }

                break;
            }
            case LayerMovement.BottomClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.y < layerPosition.y) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.down, 90);
                    }
                }

                break;
            }
            case LayerMovement.RightAntiClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.x > layerPosition.x) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.right, -90);
                    }
                }

                break;
            }
            case LayerMovement.LeftAntiClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.x < layerPosition.x) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.right, -90);
                    }
                }

                break;
            }
            case LayerMovement.TopAntiClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.y > layerPosition.y) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.up, -90);
                    }
                }

                break;
            }
            case LayerMovement.BottomAntiClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.y < layerPosition.y) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.down, -90);
                    }
                }

                break;
            }
            case LayerMovement.BackClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.z > layerPosition.z) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.forward, 90);
                    }
                }

                break;
            }
            case LayerMovement.BackAntiClockwise: {
                foreach (Piece piece in layer.pieces) {
                    if (piece.transform.position.z > layerPosition.z) {
                        piece.transform.RotateAround(layer.pivotPoint, Vector3.forward, -90);
                    }
                }

                break;
            }
        }

        layer.CompleteMovement();
        List<Piece> piecesInContact = layer.DetectPiecesInContact();
        foreach(Piece piece in piecesInContact) {
            print(piece);
        }
        layer.pieces.Clear();
        layer.pieces.AddRange(piecesInContact);
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
