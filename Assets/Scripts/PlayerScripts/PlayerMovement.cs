using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController2D controller;
    public Animator animator;

    public float movementSpeed = 40f;

    float movimentoHorizontal = 0f;
    bool jump = false;
    bool crouch = false;


    void Update()
    {
        animator.SetFloat("Speed", Mathf.Abs(movimentoHorizontal));

        movimentoHorizontal = Input.GetAxisRaw("Horizontal") * movementSpeed;

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            animator.SetBool("IsJumping", true);
        }

        if (Input.GetButtonDown("Crouch"))
        {
            crouch = true;
        } else if (Input.GetButtonUp("Crouch"))
        {
            crouch = false;
        }


    }
    public void OnCrounching (bool isCrouching)
    {
        animator.SetBool("IsCrouching", isCrouching);
    }

    public void OnLanding ()
    {
        animator.SetBool("IsJumping", false);
    }

    void FixedUpdate ()
    {
        controller.Move(movimentoHorizontal * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
