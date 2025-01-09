using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Interact1 : MonoBehaviour
{
    public bool IsInRange; // Bool to know if player is in range

    public Takkie controls;
    private InputAction interact; 

    public string Tag; // Wich tag should be interacted 
    

    public KeyCode InteractButton; 
    public UnityEvent Interacted;

    private void Awake()
    {
        controls = new Takkie();

    }

    private void OnEnable()
    {
        interact = controls.Player.Interact;
        interact.Enable();
        interact.performed += Interact;
        
    }
    private void OnDisable()
    {
        interact.Disable();
    }
    // Start is called before the first frame update


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag)) // if specify tag is in the  object
        {
            IsInRange = true; // it is in range of object
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag)) // if specify tag  exit the object
        {
            IsInRange = false; // it is no longer in range
        }
    }
   
     
    public void Interact(InputAction.CallbackContext context)
    {
        if (IsInRange)
        {
          Interacted.Invoke(); // activate unity event
        }
    }
    public void Test()
    {
        Debug.Log("test");
    }

   


}
