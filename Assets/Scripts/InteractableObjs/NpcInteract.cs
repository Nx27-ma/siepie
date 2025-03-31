using UnityEngine;
using Dialog.Game;


namespace Player.Interaction
{
  [RequireComponent(typeof(DialogInit))]
  public class NpcInteract : MonoBehaviour, IInteractable
  {
    void Start()
    {
      SubscribeToInteractEvent();
    }

    public void PlayerInteracted(GameObject player, GameObject interactedObject)
    {
      if (player.CompareTag("Human"))
      {

      }
    }

    public void SubscribeToInteractEvent()
    {
      PlayerInteractor.PlayerInteract += PlayerInteracted;
    }
  }
}