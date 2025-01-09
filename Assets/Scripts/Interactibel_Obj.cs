using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact1 : MonoBehaviour
{
    public bool IsInRange; // Bool to know if player is in range

    public string Tag; // Wich tag should be interacted 
    

    public KeyCode InteractButton; 
    public UnityEvent Interacted;

  
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
    public void Update()
    {
        if (IsInRange)
        {
            if (Input.GetKeyDown(InteractButton))
            {
                Interacted.Invoke(); // activate unity event
            }
        }
    }

   


}
