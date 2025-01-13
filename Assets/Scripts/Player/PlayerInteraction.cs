using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class PlayerInteraction : MonoBehaviour
{
  public static event Action<GameObject, GameObject> InteractPressed;
  private bool isInRange; // Bool to know if player is in range
  private string collisionTag; // Which tag should be interacted 
  private InputActionAsset actionAsset;
  private InputAction interact;
  private GameObject collidedObj;

  private void Awake()
  {
    actionAsset = Resources.Load<InputActionAsset>("Input System/PlayerControls");
    interact = actionAsset.FindAction("Interact");
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
    if (collision.gameObject.CompareTag(collisionTag)) // if specify tag is in the  object
    {
      collidedObj = collision.gameObject;
      isInRange = true; // it is in range of object
    }
  }

  private void OnTriggerExit2D(Collider2D collision)
  {
    if (collision.gameObject.CompareTag(collisionTag)) // if specify tag  exit the object
    {
      isInRange = false; // it is no longer in range
    }
  }
  public void Interact(InputAction.CallbackContext context)
  {
    if (isInRange)
    {
      InteractPressed?.Invoke(gameObject, collidedObj); // activate event action
    }
  }
}
