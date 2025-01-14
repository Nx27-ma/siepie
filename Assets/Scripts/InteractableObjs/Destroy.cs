using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour
{
    public bool Test; 
   
    public void DestroyObj(GameObject obj)
    {

        //Destroy(obj
        if (obj.activeSelf)
        {
            obj.SetActive(false);
            Debug.Log("Destroyed " + obj);

        }
        else
        {
            obj.SetActive(true);
            Debug.Log("Restored " + obj);
        }
       
        
    }
}
