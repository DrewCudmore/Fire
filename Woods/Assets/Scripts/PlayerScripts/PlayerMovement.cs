using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public float moveSpeed;

    public float groundDrag;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask GroundLayer;
    bool grounded;

    public Transform orientation;

    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    public bool canMove = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    private void Update()
    {
        // checks ground every frame
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, GroundLayer);

        MyInput();

        // slows player down while on ground (ground drag)
        // we can probably use a material if we want to
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }
    }

    void MyInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        // calculates movement direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;

        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }


    // old
    //public CharacterController controller;
    //public float speed = 12f;
    //public float gravity = -9.81f;
    //public float jumpHeight = 3f;

    //Vector3 velocity;
    //bool canMove = true; // Flag to control player movement

    //void Update()
    //{
    //    if (!canMove)
    //        return; // Don't execute movement if movement is disabled

    //    bool isGrounded = controller.isGrounded;

    //    if (isGrounded && velocity.y < 0)
    //    {
    //        velocity.y = -2f;
    //    }

    //    float x = Input.GetAxis("Horizontal");
    //    float z = Input.GetAxis("Vertical");

    //    Vector3 move = this.transform.right * x + this.transform.forward * z;
    //    controller.Move(move * speed * Time.deltaTime);

    //    velocity.y += gravity * Time.deltaTime;
    //    controller.Move(velocity * Time.deltaTime);

    //    if (isGrounded && Input.GetButtonDown("Jump"))
    //    {
    //        velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
    //    }
    //}

    public void enableMovement()
    {
        canMove = true;
    }

    public void disableMovement()
    {
        canMove = false;
    }


}
