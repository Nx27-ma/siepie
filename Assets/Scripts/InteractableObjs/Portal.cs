using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Portal : MonoBehaviour
{
    public GameObject Player;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       
        Player = collision.gameObject;
       
        
    }
   /* private void OnTriggerExit2D(Collider2D collision)
    {
        Player = null;
    }
   */
    public void Teleport(Transform position)
    {
        Player.transform.position = position.position;
    }
}
