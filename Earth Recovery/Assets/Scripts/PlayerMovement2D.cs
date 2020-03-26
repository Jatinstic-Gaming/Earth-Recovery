using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : CharacterController2D
{
    private float JumpForce = 10f;
    private float MoveSpeed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    protected override void ComputeVelocity()
    {
        Vector2 Move = Vector2.zero;

        Move.x = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && IsGrounded)
        {
            Velocity.y = JumpForce;
        }

        TargetVelocity = Move * MoveSpeed;
    }
}
