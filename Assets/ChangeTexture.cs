using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeTexture : MonoBehaviour
{

    public Material[] insideTextures; // Array of textures to cycle through
    public Material[] adhesiveTextures; // Array of textures to cycle through
    private Renderer objectRenderer;

    public void changeTexture(string cubeName) {

        if (cubeName == "Cubo-Prateado") {
            changeInsideTexture(0);
            changeAdhesiveTextures(0);
        } else if (cubeName == "Cubo-Dourado") {
            changeInsideTexture(0);
            changeAdhesiveTextures(1);
        } else if (cubeName == "Cubo-Roxo") {
            changeInsideTexture(1);
            changeAdhesiveTextures(2);
        }

    }

    void changeInsideTexture(int insideTextureIndex) {

        objectRenderer = GetComponent<Renderer>();
        objectRenderer.material = insideTextures[insideTextureIndex];
    
    }

    void changeAdhesiveTextures(int adhesiveTextureIndex) {

        int counter = 0;


         foreach (Transform child in transform)
        {
            counter++; 
            Renderer childRenderer = child.GetComponent<Renderer>();

            if (childRenderer != null)
            {
                childRenderer.material = adhesiveTextures[adhesiveTextureIndex];
            }
        }

        print(counter);

    }

}
