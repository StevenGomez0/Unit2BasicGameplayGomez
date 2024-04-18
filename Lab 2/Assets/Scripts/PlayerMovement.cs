using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed;

    public float groundDrag;

    public float playerHeight;
    public LayerMask whatIsGround;
    bool grounded;

    private float horizontalInput;
    private float verticalInput;

    public Transform orientation;
    Rigidbody rb;

    Vector3 moveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
    }

    private void Update()
    {
        //checking if player is on ground using a ray and layer check
        grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight * 0.5f + 0.2f, whatIsGround);

        //disables rb drag if player is not grounded
        if (grounded)
        {
            rb.drag = groundDrag;
        }
        else
        {
            rb.drag = 0;
        }

        MyInput();
        SpeedControl();
    }

    private void FixedUpdate()
    {
        MovePlayer();
    }

    void MyInput()
    {
        //inputs
        horizontalInput = Input.GetAxisRaw("Horizontal");
        verticalInput = Input.GetAxisRaw("Vertical");
    }

    void MovePlayer()
    {
        //modifies a Vector3 for movement direction based on camera direction
        moveDirection = orientation.forward * verticalInput + orientation.right * horizontalInput;
        //adds force in facing direction
        rb.AddForce(moveDirection.normalized * moveSpeed * 10f, ForceMode.Force);
    }

    void SpeedControl()
    {
        //if velocity exceeds moveSpeed, make current flatVel = to a limited Velocity and apply velocity

        Vector3 flatVel = new Vector3(rb.velocity.x, 0f, rb.velocity.z);

        //limit velocity if past moveSpeed
        if(flatVel.magnitude > moveSpeed)
        {
            //im not entirely sure why but i dont put the normalized after flatVel the player gets flung forever away. 
            Vector3 limitedVel = flatVel.normalized * moveSpeed;
            rb.velocity = new Vector3(limitedVel.x, rb.velocity.y, limitedVel.z);
        }
    }
}
