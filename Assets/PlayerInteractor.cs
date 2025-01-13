using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractor : MonoBehaviour
{
    public static event Action<GameObject, GameObject> PlayerInteract;
    public float InteractDistance = 2.5f;
    public List<GameObject> InteractableObjects; //A list over all nearby interactable game objects

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //When scene is loaded, all game objects with interactable tag is added to list
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
            //If distance between an object and the player is less than the interact distance, invoke is called and the object
            //is interacted with.
            if(Vector3.Distance(curObj.transform.position, this.transform.position) < InteractDistance)
            {
                //Invoke sends both this game object and the object it's trying to interact with
                PlayerInteract?.Invoke(this.gameObject, curObj);
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
