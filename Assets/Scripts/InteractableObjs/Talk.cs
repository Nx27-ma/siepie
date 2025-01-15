using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Talk : PlayerInteraction
{
    public override void PlayerInteracted(GameObject player, GameObject interactedObject)
    {
        base.PlayerInteracted(player, interactedObject);
        if(interactedObject == this.gameObject)
        {
            if (player.CompareTag("Cat"))
            {
                Debug.Log("Hello there good fellow");
            }
            else
            {
                Debug.Log("SCRAAAAAAAAW");
            }
        }
    }
}
