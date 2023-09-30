using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] Transform orientation;
    private Rigidbody rb;
    private Vector3 moveDirection;
    private float dragForce;
    [SerializeField] private float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Follow player if not be seen
        if (!CheckPlayerView.hasBeenSeen)
        {
            CalculateDrag();
            LimitedSpeed();
            MoveToPlayer();
        }

        else
        {
            StopMoving();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CalculateDrag()
    {
        dragForce = moveSpeed / 100;
        rb.drag = dragForce;
    }

    void MoveToPlayer()
    {
        rb.constraints = RigidbodyConstraints.FreezeRotation;

        moveDirection = orientation.forward * moveSpeed;
        rb.AddForce(moveDirection * moveSpeed);
    }

    void LimitedSpeed()
    {
        // Get velocity magnitude on z position
        Vector3 flatVelocity = new Vector3(0, 0, rb.velocity.z);
        if (flatVelocity.magnitude > moveSpeed)
        {
            rb.velocity = flatVelocity.normalized * moveSpeed;
        }
    }

    void StopMoving()
    {
        rb.constraints = RigidbodyConstraints.FreezeAll;
    }
}
