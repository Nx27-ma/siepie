using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Interact1 : MonoBehaviour
{
    public string test;
    public UnityEvent interacted;
    // Start is called before the first frame update
    

    public void Activate ()
    {
        interacted.Invoke();
    }

    public void Test()
    {
        Debug.Log(test);
    }

}
