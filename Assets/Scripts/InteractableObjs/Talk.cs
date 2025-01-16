using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Talk : PlayerInteraction
{
    //I call my potato a structure the way it's so structurally sound -Henry
    public struct Potato
    {
        public static bool has = false;
    }

    //GIVE ME A DIALOGUE SYSTEM NORA AND MY LIFE IS YOURS -Henry
    public override void PlayerInteracted(GameObject player, GameObject interactedObject)
    {
        if(interactedObject == this.gameObject)
        {
            if (player.CompareTag("Cat") && Potato.has == false)
            {
                Debug.Log("Hello there good fellow, would you mind fetching me that potato across the wall? I'm just a bit too...Rotund, to fly over and get it myself.");
            }
            else if(player.CompareTag("Cat") && Potato.has == true)
            {
                Debug.Log("Jolly good chum! I'm forever in your debt, now excuse my while i dine on some exquisite cuisine... *Ungodly bird eating sounds");
            }
            else if (player.CompareTag("Human") && Potato.has == false)
            {
                Debug.Log("SCRAAAAAAAAW");
            }
            else
            {
                Debug.Log("*You throw the potato to the sparrow and it jumps at it like a tiger to it's prey. The scene you witness makes you feel oddly grotesqued with the way it's devouring the spud.");
            }
        }
    }
}
