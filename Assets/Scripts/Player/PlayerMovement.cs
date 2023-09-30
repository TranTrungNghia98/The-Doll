using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Transform orientation;
    private Rigidbody rb;

    [Header("Keybinds")]
    [SerializeField] KeyCode runkey = KeyCode.LeftShift;

    private float horizontalInput;
    private float verticalInput;

    private float walkSpeed = 10;
    private float runSpeed = 13;
    private float dragForce;
    private float moveSpeed;
    private Vector3 moveDirection;

    private enum MovementState
    {
        walking,
        running
    }

    private MovementState movementState;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        CalculateDragForce();
        ControlMoveSpeed();
        MovePlayer();
    }

    // Update is called once per frame
    void Update()
    {
        GetInput();
        StateHandle();
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void StateHandle()
    {
        if(Input.GetKey(runkey))
        {
            movementState = MovementState.running;
        }
        else if (Input.GetKeyUp(runkey))
        {
            movementState = MovementState.walking;
        }
    }

    void CalculateDragForce()
    {
        dragForce = moveSpeed / 100;
        rb.drag = dragForce;
    }

    void MovePlayer()
    {
        // Change move speed depend movement state
        if (movementState == MovementState.walking)
        {
            moveSpeed = walkSpeed;
        }

        else
        {
            moveSpeed = runSpeed;
        }

        moveDirection = orientation.right * horizontalInput + orientation.forward * verticalInput;
        rb.AddForce(moveDirection * moveSpeed, ForceMode.Force);
    }

    void ControlMoveSpeed()
    {
        // Find current move speed
        Vector3 flatVel = new Vector3(rb.velocity.x, 0, rb.velocity.z);

        // Prevent current speed bigger than movespeed
        if (flatVel.magnitude > moveSpeed)
        {
            rb.velocity = flatVel.normalized * moveSpeed;
        }
    }
}
