﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement2D : CharacterController2D
{
    private float JumpForce = 16f;
    private float MoveSpeed = 8f;

    private Animator Animator;

    // Start is called before the first frame update
    void Awake()
    {
        Animator = GetComponentInChildren<Animator>();
    }

    protected override void ComputeVelocity()
    {
        Vector2 Move = Vector2.zero;

        Move.x = Input.GetAxis("Horizontal");

        if (Input.GetButton("Jump") && IsGrounded)
        {
            Velocity.y = JumpForce;
        }

        Animator.SetFloat("Speed", (Velocity.x)/MoveSpeed);
        Animator.SetBool("IsGrounded", IsGrounded);
        if (Animator.GetFloat("Speed") < -0.01)
        {
            Animator.SetBool("IsFacingRight", false);
        }
        else
        {
            Animator.SetBool("IsFacingRight", true);
        }

        TargetVelocity = Move * MoveSpeed;
    }
}
