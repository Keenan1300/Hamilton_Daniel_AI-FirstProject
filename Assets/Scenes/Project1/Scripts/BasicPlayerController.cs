using NodeCanvas.Tasks.Actions;
using UnityEngine;

public class BasicPlayerController : MonoBehaviour
{
    float moveSpeed = 4f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");

        // Create a movement vector
        Vector3 movement = new Vector3(horizontalInput, 0f, verticalInput);

        // Set the Rigidbody's velocity directly
        // Note: You do not multiply by Time.deltaTime when setting velocity directly in FixedUpdate
        transform.position += movement * moveSpeed;
    }
}
