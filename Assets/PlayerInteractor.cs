using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractor : MonoBehaviour
{
    public float InteractDistance = 2.5f;
    public List<GameObject> InteractableObjects; //A list over all nearby interactable game objects

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    public void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        foreach(GameObject curObj in GameObject.FindGameObjectsWithTag("Interactable"))
        {
            InteractableObjects.Add(curObj);
        }
    }

    //Function called when interact input from the Player Input component is received
    public void OnInteract()
    {
        foreach(GameObject curObj in InteractableObjects)
        {
            if(Vector3.Distance(curObj.transform.position, this.transform.position) < InteractDistance)
            {
                if(tag == "Cat")
              {
                    curObj.BroadcastMessage("SiepieInteract");
              }
                else
                {
                    curObj.BroadcastMessage("TakkieInteract");
                }
            }
        }
    }
#if UNITY_EDITOR
    private void FixedUpdate()
    {
        foreach (GameObject curObj in InteractableObjects)
        {
            if (Vector3.Distance(curObj.transform.position, this.transform.position) < InteractDistance)
            {
                Debug.DrawLine(curObj.transform.position, this.transform.position, Color.green);
            }
            else
            {
                Debug.DrawLine(curObj.transform.position, this.transform.position, Color.red);
            }
        }
        
    }
#endif
}
