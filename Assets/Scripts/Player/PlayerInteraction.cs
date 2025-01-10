using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class PlayerInteraction : MonoBehaviour
{
  public bool IsInRange; // Bool to know if player is in range
  public string Tag; // Which tag should be interacted 
  public UnityEvent Interacted;
  public ActionMap Controls;

  private InputAction interact;

  private void Awake()
  {
    Controls = new ActionMap();
  }

  private void OnEnable()
  {
    interact = Controls.Player.Interact;
    interact.Enable();
    interact.performed += Interact;
  }
  private void OnDisable()
  {
    interact.Disable();
  }

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
            Debug.Log("Interacted with " + Tag);
      Interacted.Invoke(); // activate unity event
    }
  }
}
