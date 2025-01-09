using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement: MonoBehaviour
{

    public float MoveSpeed;
    public bool CanSprint;
    public float SprintSpeed;
    public KeyCode Up,Down,Left,Right,Sprint;
    

    
    bool moveUp, moveDown, moveLeft, moveRight,sprinting;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(Up);
        moveDown = Input.GetKey(Down);
        moveLeft = Input.GetKey(Left);
        moveRight = Input.GetKey(Right);
        sprinting = Input.GetKey(Sprint);

        if (CanSprint && sprinting)
        {
            MoveSpeed = SprintSpeed;
        }
        else
        {
            MoveSpeed = 3;
        }
      
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = MoveSpeed * Time.deltaTime;
        Vector2 move = Vector2.zero;

        if (moveUp)
        {
            move.y = moveAmount;
        }
        if (moveDown)
        {
            move.y -= moveAmount;
        }
        if (moveLeft)
        {
            move.x -= moveAmount;
        }
        if (moveRight)
        {
            move.x = moveAmount;
        }

        float moveMagnitude = Mathf.Sqrt(move.x * move.x + move.y * move.y);
        if (moveMagnitude > moveAmount)
        {
            float ratio = moveAmount / moveMagnitude;
            move *= ratio;
        }
        pos += move;

        

        transform.position = pos;
    }
}
