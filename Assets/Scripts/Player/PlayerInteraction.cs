using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
  public UnityEvent SiepieInteracted, TakkieInteracted;

  public void InRange()
  {
   /*
    Haven't implemented it yet but thinking we can use this to display a interact pop up, make it more clear that the player is standing next to an interactable
    object. -Henry
   */
  }

    //Both functions are called when they receive their message from a players PlayerInteractor script
  public void SiepieInteract()
  {
      SiepieInteracted.Invoke(); //activate the Siepie interaction unity event
  }

  public void TakkieInteract()
  {
      TakkieInteracted.Invoke(); //activate the Takkie interaction unity event
  }

    
}
