using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] float sprintSpeed = 7f;
    [SerializeField] float jumpForce = 5f;

    Rigidbody rb;
    CapsuleCollider col;

    bool isCursorLocked = true;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        rb = GetComponent<Rigidbody>();
        col = GetComponent<CapsuleCollider>();
    }
    
    void Update()
    {
        // Check if the player is holding down the shift key to sprint
        float currentSpeed = speed;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = sprintSpeed;
        }

        // Move the player
        Vector2 moveInput = Vector2.zero;
        moveInput.x = Input.GetAxis("Horizontal") * currentSpeed;
        moveInput.y = Input.GetAxis("Vertical") * currentSpeed;
        moveInput *= Time.deltaTime;
        transform.Translate(moveInput.x, 0, moveInput.y);

        // Jump
        if (IsGrounded() && Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        
        // Unlock the cursor
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
    
    bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, col.bounds.extents.y + 0.1f);
    }
}
