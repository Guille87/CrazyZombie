using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float sprintSpeed = 7f;
    [SerializeField] float jumpForce = 1f;
    [SerializeField] float gravity = -9.81f;

    CharacterController controller;
    Vector3 velocity;

    bool isCursorLocked = true;

    void Start()
    {
        controller = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    
    void Update()
    {
        // Calculate the movement speed
        float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : speed;

        // Get the input from the player
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        // Direction of movement relative to the player
        Vector3 move = transform.right * moveX + transform.forward * moveZ;

        // Move the player
        controller.Move(move * currentSpeed * Time.deltaTime);

        if (controller.isGrounded)
        {
            if (velocity.y < 0f)
                velocity.y = -0.1f;
            
            // Jump
            if (Input.GetButtonDown("Jump"))
            {
                velocity.y = Mathf.Sqrt(jumpForce * -2f * gravity); // Calculate the jump velocity
            }
        }

        // Apply gravity
        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
        
        // Toggle the cursor
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isCursorLocked)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;  // Show cursor
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;  // Hide cursor
            }
            isCursorLocked = !isCursorLocked;  // Toggle the cursor state
        }

        // Lock the cursor
        if (Input.GetMouseButtonDown(0) && !isCursorLocked)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            isCursorLocked = true;
        }
    }
}
