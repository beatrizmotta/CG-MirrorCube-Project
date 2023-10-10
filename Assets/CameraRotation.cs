using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    public Transform cube; 
    public float rotationSpeed = 2.0f;
    private Vector3 initialPosition; 
    private Quaternion initialRotation; 

    private Vector3 lastMousePosition;

    void Start() {
        initialPosition = transform.position;
        initialRotation = transform.rotation;
    }

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Vector3 currentMousePosition = Input.mousePosition;

            Vector3 mouseDelta = currentMousePosition - lastMousePosition;

            float rotationX = mouseDelta.y * rotationSpeed;
            float rotationY = -mouseDelta.x * rotationSpeed;

            transform.RotateAround(cube.position, Vector3.up, rotationY);
            transform.RotateAround(cube.position, transform.right, rotationX);
        }

        lastMousePosition = Input.mousePosition;
    }

    public void Reset() {
        transform.rotation = initialRotation;
        transform.position = initialPosition;
    }
}
