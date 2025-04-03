using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player.Interaction;

public class OpenGate : MonoBehaviour,IInteractable
{
    public GameObject gate;
    // Optional: You can use this method to subscribe to any events if needed.
    public void SubscribeToInteractEvent()
    {
        // Implementation can be added here if needed.
    }

    // This method is called when the player interacts with this object.
    public void PlayerInteracted(GameObject player, GameObject interactedObject)
    {
        Debug.Log($"{gameObject.name} was interacted with by {player.name} and {gate.name} will be destroyed.");
        gate.SetActive(false);
        
    }
}
