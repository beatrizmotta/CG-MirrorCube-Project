using System.Collections;
using UnityEngine;
using System;
using App;

public class CubeManager : MonoBehaviour {
    public Material[] adhesiveTextures; 
    public Material[] insideTextures;

    void Start() {
        int identifier = PlayerPrefs.GetInt("cubeIdentifier");
        this.changeTexture(identifier);
    }

    public void changeTexture(int identifier = 1) {
        if (Enum.IsDefined(typeof(TextureIdentifier), identifier)) {
            GameObject[] pieceStickerObjects = GameObject.FindGameObjectsWithTag("PieceSticker");
            GameObject[] pieceObjects = GameObject.FindGameObjectsWithTag("Piece");
            Material adhesiveTexture = this.getAdhesiveTexture(identifier);
            Material insideTexture = this.getInsideTexture(identifier);

            foreach (GameObject item in pieceStickerObjects) {
                PieceSticker sticker = item.GetComponent<PieceSticker>();
                sticker.changeTexture(adhesiveTexture);
            }

            foreach (GameObject item in pieceObjects) {
                Piece piece = item.GetComponent<Piece>();
                piece.changeTexture(insideTexture);
            }
        }
    }

    private Material getInsideTexture(int identifier) {
        int index = (TextureIdentifier) identifier == TextureIdentifier.Purple ? 1 : 0;
        return this.insideTextures[index];
    }

    private Material getAdhesiveTexture(int identifier) {
        return this.adhesiveTextures[identifier];
    }
}
