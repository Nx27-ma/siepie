using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaikiController : MonoBehaviour
{
    Rigidbody2D m_Rigidbody;
    public float MoveSpeed = 2f;
    Vector2 moveValue;

    private void OnEnable()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
    }
    //Function is called when Takkie receives the OnTakkieMove input from the PlayerInput component
    //Value of the Vector2 value is read as Value
    public void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    private void FixedUpdate()
    {
        Vector2 move = transform.up * moveValue.y * MoveSpeed + transform.right * moveValue.x * MoveSpeed;
        m_Rigidbody.velocity = move;
        Debug.Log(m_Rigidbody.velocity);
    }
}
