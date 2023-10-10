using UnityEngine;

public class PieceSticker : MonoBehaviour {
    private Material texture;

    public void changeTexture(Material texture) {
        Renderer renderer = GetComponent<Renderer>();
        renderer.material = texture;
        this.texture = texture;
    }
}
