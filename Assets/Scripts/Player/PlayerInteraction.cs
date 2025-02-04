using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{

    private void Start()
    {
        PlayerInteractor.PlayerInteracted += PlayerInteracted;
    }

    public void InRange()
  {
   /*
    Haven't implemented it yet but thinking we can use this to display a interact pop up, make it more clear that the player is standing next to an interactable
    object. -Henry
   */
  }

    //Function called from PlayerInteractor invoke
  public void PlayerInteracted(GameObject player, GameObject interactedObject)
  {
        Debug.Log("Interacting with " + interactedObject.name + ".");
  }

    
}
