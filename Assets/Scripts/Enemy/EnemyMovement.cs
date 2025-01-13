using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class EnemyMovement : MonoBehaviour
{
    
    GameObject[] Players, ClosestGameObj;
    [SerializeField] float Range = 2;
    int Layermask;
    bool HasTarget = false;
    void Start()
    {
        Layermask = LayerMask.GetMask("Entity");
        Players = GameObject.FindGameObjectsWithTag("Player");
    }


    void Update()
    {



        //    if (Physics.Raycast(gameObject.transform.position, Players[0].transform.position, Range, Layermask))
        //    {
        //        HasTarget = true;
        //    } 
        //    else if ( Physics.Raycast(gameObject.transform.position, Players[1].transform.position, Range, Layermask))
        //    {
        //        HasTarget = true;
        //    } 
        //    else
        //    {
        //        HasTarget = false;
        //    }

        //    if (HasTarget)
        //    {

        //    }
    }
}
