using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 5f;
    public float maxSpeed = 10f;
    public Transform cameraTransform; // Reference to the camera's transform
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrows

        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        forward.y = 0f; // Keep movement on the horizontal plane
        right.y = 0f;   // Keep movement on the horizontal plane

        forward.Normalize();
        right.Normalize();

        Vector3 movement = (forward * moveZ) + (right * moveX); // moveZ = W/S keys → value between -1 and 1, moveX is likewise for A/D keys
        rb.AddForce(movement * speed);

        if (rb.linearVelocity.magnitude > maxSpeed)
        {
            rb.linearVelocity = rb.linearVelocity.normalized * maxSpeed;
        }

    }
}