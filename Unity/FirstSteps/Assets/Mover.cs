using UnityEngine;

public class Mover : MonoBehaviour
{
    public float speed = 5f;

    void Update()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right arrows
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down arrows

        Vector3 movement = new Vector3(moveX, moveZ, 0f);

        transform.Translate(movement * speed * Time.deltaTime);
    }
}