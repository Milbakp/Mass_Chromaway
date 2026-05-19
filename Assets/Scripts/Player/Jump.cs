using UnityEngine;

public class Jump : MonoBehaviour
{
    [Header("Jump Settings")]
    public float jumpForce, superJumpForce;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float checkRadius = 0.3f;

    private Rigidbody rb; 
    private bool isGrounded;
    private Inventory inventory;
    public float spaceHoldTime = 0f;
    private float totalRotation = 0f;
    public bool superJumpBool = false;

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
            jumpForce = Random.Range(12f, 15f); // Randomize jump force for varied jump height
            fallMultiplier = Random.Range(4f, 7f); // Randomize fall multiplier for varied jump feel
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
        if(superJumpBool)
        {
            rb.AddForce(Vector3.up * superJumpForce, ForceMode.Impulse);
            superJumpBool = false; // Reset super jump after use
        }
        else
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
        //rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }
    void backFlip()
    {
        transform.Rotate(Vector3.right * 360 * Time.deltaTime);
        totalRotation += Mathf.Abs(360 * Time.deltaTime);

        if (totalRotation >= 360f)
        {
            inventory.removeOneColourFlip();
            totalRotation -= 360f; // Keep the remainder
            Debug.Log("Full Rotation!");
        }
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

    public void incompleteFlip()
    {
        transform.rotation = Quaternion.identity;
        rb.angularVelocity = Vector3.zero;
        inventory.shatterCubes();
    }
    void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.gameObject.CompareTag("Ground") && !isGrounded)
        {
            incompleteFlip();
            Debug.Log("Landed on the ground after a flip!");
        }
    }
}
