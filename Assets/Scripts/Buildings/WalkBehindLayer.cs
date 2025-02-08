using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WalkBehindLayer : MonoBehaviour
{
    public Transform player;
    public float test;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        test = player.position.y / gameObject.transform.position.y;
    }
}
