using UnityEngine;

public class Piece : MonoBehaviour {
    private Material texture;

    public void changeTexture(Material texture) {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = texture;
        this.texture = texture;
    }
}