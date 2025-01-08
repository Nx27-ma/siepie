using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact : MonoBehaviour
{
    public KeyCode InteractButton;
    public Interact1 InteractObj;
    public bool interact;

    public bool test;


    // Update is called once per frame
    void Update()
    {
       interact = Input.GetKey(InteractButton);

        
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        InteractObj = collision.gameObject.GetComponent<Interact1>(); // find the script in the object it is colliding with
        

        if (collision.CompareTag("Interactibel") && interact)
        {
            InteractObj.Activate();
        }
       
    }
}

