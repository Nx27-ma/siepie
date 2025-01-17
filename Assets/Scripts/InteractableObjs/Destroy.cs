using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : PlayerInteraction
{
    public GameObject TargetDestroy, ObjToHold;
    SpriteRenderer Renderer;
    private void OnEnable()
    {
        Renderer = gameObject.GetComponent<SpriteRenderer>();
    }

    public override void PlayerInteracted(GameObject player, GameObject interactedObject)
    {
        if(interactedObject == this.gameObject)
        {
            //Destroys a target object and sets the sprite renderer color to green -Henry
            if (TargetDestroy.activeSelf)
            {
                Renderer.color = Color.green;
                Debug.Log(this.gameObject.name + " Destroyed " + TargetDestroy.name);
                if (this.gameObject.name == "Potato")
                {
                    Talk.Potato.has = true;
                    ObjToHold = this.gameObject;
                }
                TargetDestroy.SetActive(false);
            }
            else if (!TargetDestroy.activeSelf) 
            {
                Debug.Log(TargetDestroy.name + " is already inactive.");
            }
        }
    }
}
