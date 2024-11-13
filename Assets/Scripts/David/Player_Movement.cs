using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement: MonoBehaviour
{

    public float moveSpeed;
    public KeyCode up,down,left,right;

    
    bool moveUp, moveDown, moveLeft, moveRight;
    
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        moveUp = Input.GetKey(up);
        moveDown = Input.GetKey(down);
        moveLeft = Input.GetKey(left);
        moveRight = Input.GetKey(right);

      
    }

    private void FixedUpdate()
    {
        Vector2 pos = transform.position;

        float moveAmount = moveSpeed * Time.deltaTime;
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
