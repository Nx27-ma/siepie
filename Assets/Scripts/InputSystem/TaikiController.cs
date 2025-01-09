using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaikiController : MonoBehaviour
{
    Rigidbody2D rb;
    public float MoveSpeed = 2f;
    Vector2 moveValue;

    //Neccesary components fetched on enable -Henry
    private void OnEnable()
    {
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
        Vector2 move = transform.up * moveValue.y * MoveSpeed + transform.right * moveValue.x * MoveSpeed;
        rb.velocity = move;
    }
}
