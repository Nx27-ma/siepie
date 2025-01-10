using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
  public bool IsInRange; // Bool to know if player is in range
  public string Tag; // Which tag should be interacted 
  public KeyCode InteractButton;
  public UnityEvent Interacted;
  public InputActionAsset ActionAsset;
  private InputAction interact;

    private void Awake()
    {
        ActionAsset = Resources.Load("ActionMap") as InputActionAsset;
        interact = ActionAsset.FindAction("Interact");
    }

    private void OnEnable()
    {
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
  public void Interact(InputAction.CallbackContext context )
  {
        Debug.Log("Input works");
    if (IsInRange)
    {
            Debug.Log("Range works");
      Interacted.Invoke(); // activate unity event
    }
  }
}
