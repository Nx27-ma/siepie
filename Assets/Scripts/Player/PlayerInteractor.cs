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
    List<GameObject> objectsToInteract = new List<GameObject>();

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

                objectsToInteract.Add(curObj);
            }
        }
        if (objectsToInteract.Count == 1)
        {
            PlayerInteract?.Invoke(this.gameObject, objectsToInteract[0]);
            objectsToInteract.Remove(objectsToInteract[0]);
        }
        else if (objectsToInteract.Count > 1)
        {
            objectsToInteract.Sort(delegate (GameObject gameObject1, GameObject gameObject2)
            {
                return Vector3.Distance(gameObject1.transform.position, this.transform.position).CompareTo(Vector3.Distance(gameObject2.transform.position, this.transform.position));
            });
            PlayerInteract?.Invoke(this.gameObject, objectsToInteract[0]);
            objectsToInteract.RemoveAll(x => x.CompareTag("Interactable"));
        }
        else
        {
            Debug.Log(this.gameObject.name + " found no object to interact with.");
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
            else if (curObj == null)
            {
                InteractableObjects.Remove(curObj);
            }
            else
            {
                Debug.DrawLine(curObj.transform.position, this.transform.position, Color.red);
            }
        }
        
    }
#endif
}
