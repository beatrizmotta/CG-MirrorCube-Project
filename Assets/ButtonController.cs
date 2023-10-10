using UnityEngine;
using App;

public class ButtonController : MonoBehaviour {
    public LayerMovement movement;

    public void RotateLayer() {
        GameObject layerManagerObject = GameObject.Find("LayerManager");
        LayerManager layerManager = layerManagerObject.GetComponent<LayerManager>();
        layerManager.RotateLayer(this.movement);
    }
}
