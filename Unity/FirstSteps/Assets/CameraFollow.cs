using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public float distance = 10f;
    public float height = 5f;
    public float rotationSpeed = 100f;
    public float smoothSpeed = 0.125f;

    private float currentAngle = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        float mouseX = Input.GetAxis("Mouse X");
        currentAngle += mouseX * rotationSpeed * Time.deltaTime;

        float radians = currentAngle * Mathf.Deg2Rad;
        float camX = target.position.x + distance * Mathf.Sin(radians);
        float camZ = target.position.z + distance * Mathf.Cos(radians);
        float camY = target.position.y + height;

        Vector3 desiredPosition = new Vector3(camX, camY, camZ);
        transform.position = Vector3.Lerp(
            transform.position,
            desiredPosition,
            smoothSpeed
        );
        transform.LookAt(target);
    }
}