using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractor : MonoBehaviour
{
    public List<GameObject> InteractableObjects = new List<GameObject>(); //A list over all nearby interactable game objects

    /*
    Trigger collider on player is currently only meant to pickup objects on the "Interactable tab", this may of course change but that's just how I have it set
    up right now -Henry
    */


    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If the GameObject that the player has collided with does not exist within the nearby interactable game objects list...
        if (!InteractableObjects.Contains(collision.gameObject))
        {
            //...that GameObject is added to the list...
            InteractableObjects.Add(collision.gameObject);
        }
        else
        {
            //...Otherwise a debug warning is sent that something has gone wrong.
            Debug.LogWarning(collision.gameObject.name + " was not found in InteractableObjects list during trigger enter. Add function not called.");
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        //If the GameObject that the player has collided with exists within the nearby interactable game objects list...
        if (InteractableObjects.Contains(collision.gameObject))
        {
            //...That GameObject is removed from the list...
            InteractableObjects.Remove(collision.gameObject);
        }
        else
        {
            //...Otherwise a debug warning is sent that something has gone wrong.
            Debug.LogWarning(collision.gameObject.name + " was not found in InteractableObjects list during trigger exit. Remove function not called.");
        }
    }

    //Function called when interact input from the Player Input component is received
    public void OnInteract()
    {
        //Finds out which player is interacting with the nearest interactable object and sends a message for it to use it's function respective for each player.
        if(this.tag == "Cat")
        {
            InteractableObjects[0].BroadcastMessage("SiepieInteract");
        }
        else
        {
            InteractableObjects[0].BroadcastMessage("TakkieInteract");
        }
    }
}
