using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePickup : PlayerInteraction
{
    public GameObject takkie;
    public Animator animator;
    public SpriteRenderer thisObjSprite;

    public override void PlayerInteracted(GameObject player, GameObject interactedObject)
    {
        if(player.CompareTag("Human") && interactedObject == this.gameObject)
        {
            Debug.Log("Interacting");
            TakkiePickup.spriteToShow = thisObjSprite.sprite;
            animator.SetTrigger("Pickup");
            Talk.Potato.has = true;
            this.gameObject.SetActive(false);
        }
    }
}
