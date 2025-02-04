using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
  [SerializeField] float MoveSpeed = 2f;

  Rigidbody2D rb;
  Vector2 inputSystemVector;
  Vector2 moveAmount;

  //Neccesary components fetched on enable -Henry ~changed it to start for performance 
  private void Start()
  {
    rb = GetComponent<Rigidbody2D>();
  }
  //Function is called when Takkie receives the OnTakkieMove input from the PlayerInput component
  //Value of the Vector2 value is read as Value -Henry
  public void OnMove(InputValue value)
  {
    inputSystemVector = value.Get<Vector2>();
  }

  //Velocity is changed based on the value of the vector received to inputSystemVector during OnMove -Henry
  private void FixedUpdate()
  {
    moveAmount = transform.up * inputSystemVector.y * MoveSpeed + transform.right * inputSystemVector.x * MoveSpeed;
    rb.velocity = moveAmount;
  }
}
