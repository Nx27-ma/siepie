using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Player.Interaction; // Ensure this matches your project structure

public class Talk : MonoBehaviour, IInteractable
{
    public TextMeshPro text;

    // I call my potato a structure the way it's so structurally sound -Henry
    public struct Potato
    {
        public static bool has = false;
        public static bool hasgiven = false;
    }

    // SubscribeToInteractEvent is required by the IInteractable interface.
    // You can leave it empty if no additional event subscriptions are needed.

    public void Start()
    {
        SubscribeToInteractEvent();
    }
    public void SubscribeToInteractEvent()
    {
        PlayerInteractor.PlayerInteract += PlayerInteracted;
    }

    // This method is called when the player interacts with this object.
    public void PlayerInteracted(GameObject player, GameObject interactedObject)
    {
        if (interactedObject == this.gameObject)
        {
            // Get the Inventory component from the player (if it exists)
            Inventory inventory = player.GetComponent<Inventory>();
            // Check if the inventory contains the potato item (assumed itemID is 1)
            bool hasPotato = (inventory != null) && inventory.HasItemID(1);

            if (player.CompareTag("Cat") && Potato.hasgiven == false)
            {
                text.text = "Hello there good fellow, could you give me a potato?";
            }
            else if (player.CompareTag("Cat") && Potato.hasgiven == true)
            {
                text.text = "Jolly good chum! I'm forever in your debt";
            }
            else if (player.CompareTag("Human") && !hasPotato)
            {
                text.text = "SCRAAAAAAAAW";
            }
            else if (player.CompareTag("Human") && hasPotato)
            {
                text.text = "(Happy) SCRAAAAAW";
                Potato.hasgiven = true;
            }
        }
    }
}
