using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce = 7f;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius = 0.3f;

    private Rigidbody rb; 
    private bool isGrounded;
    private Inventory inventory;
    public float spaceHoldTime = 0f;
    //private bool isBackFlipping = false;

    void Start()
    {
        // Get the 3D Rigidbody
        rb = GetComponent<Rigidbody>();
        inventory = FindAnyObjectByType<Inventory>();
    }

    void Update()
    {
        // Check for ground using a Sphere instead of a Circle
        isGrounded = Physics.CheckSphere(groundCheck.position, checkRadius, groundLayer);

        // Jump Input
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jumping();
        }

        if(Input.GetKey(KeyCode.Space) && !isGrounded)
        {
             spaceHoldTime += Time.deltaTime;
             if(spaceHoldTime > 1f)
             {
                backFlip();
             }
        }

        if(Input.GetKeyUp(KeyCode.Space))
        {
            spaceHoldTime = 0f;
        }

    }

    void Jumping()
    {
        // Reset Y velocity so every jump is the same height
        rb.linearVelocity = new Vector3(rb.linearVelocity.x, 0, rb.linearVelocity.z);
        
        // Use ForceMode.Impulse for immediate 3D force
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void backFlip()
    {
        transform.Rotate(Vector3.right * 360 * Time.deltaTime);
    }

    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 2f;

    void FixedUpdate() 
    {
        if (rb.linearVelocity.y < 0) // Falling down
        {
            rb.linearVelocity += Vector3.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        } 
        else if (rb.linearVelocity.y > 0 && !Input.GetButton("Jump")) // Short jump tap
        {
            rb.linearVelocity += Vector3.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}
