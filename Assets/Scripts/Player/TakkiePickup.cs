using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TakkiePickup : MonoBehaviour
{
    public static Sprite spriteToShow;
    public SpriteRenderer spriteRenderer;
    
    public void PutWhere()
    {
        if (spriteRenderer.sprite == null)
        {
            spriteRenderer.sprite = spriteToShow;
        }
        else
        {
            spriteRenderer.sprite = null;
        }
    }
}
