using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : PlayerInteraction
{
    public Transform Destination;
    public override void PlayerInteracted(GameObject player, GameObject interactedObject)
    {
        if(interactedObject == this.gameObject && player.CompareTag("Cat"))
        {
            //Positions Siepie to the specified transform.position. -Henry
            player.transform.position = Destination.transform.position;
            Debug.Log(this.gameObject.name + " Teleporting");
        }
    }
}
