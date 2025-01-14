using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TakkieMovement : MonoBehaviour
{
    int currentWalkAnim;
  public float MoveSpeed = 2f;
  Rigidbody2D rb;
  Vector2 moveValue;
  Animator animator;
  Vector2 zero = new Vector2(0, 0);

  //Neccesary components fetched on enable -Henry
  private void OnEnable()
  {
    animator = GetComponent<Animator>();
    rb = GetComponent<Rigidbody2D>();
  }
  //Function is called when Takkie receives the OnTakkieMove input from the PlayerInput component
  //Value of the Vector2 value is read as Value -Henry
  public void OnMove(InputValue value)
  {
    moveValue = value.Get<Vector2>();
  }

  //Velocity is changed based on the value of the vector received to moveValue during OnMove -Henry
  private void FixedUpdate()
  {
    Vector2 move = transform.up * moveValue.y + transform.right * moveValue.x;
    animator.SetFloat("X", moveValue.x);
    animator.SetFloat("Y", moveValue.y);
    if (move == zero)
    {
        animator.SetBool("Moving", false);
    }
    else
    {
        animator.SetBool("Moving", true);
    }
    rb.velocity = move * MoveSpeed;
        Debug.Log(this.tag + ": " + move);
  }

  public void ChangeCurrentWalkAnim(int value)
  {
        animator.SetInteger("WalkAnim", value);
  }
}
