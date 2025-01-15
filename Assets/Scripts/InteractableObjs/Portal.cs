using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject Player;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Player = collision.gameObject;
        Debug.Log(gameObject.name + " Found " + collision.tag);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        Player = null;
        Debug.Log(gameObject.name + " Lost " + collision.tag);
    }
   
    public void Teleport(Transform position)
    {
        StartCoroutine(Activate(position));
    }

    IEnumerator Activate (Transform position)
    {
        yield return null;
        Player.transform.position = position.position;
    }
}
