using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerInteractor : MonoBehaviour
{
    bool controlLocked = false;
    public static event Action<GameObject, GameObject> PlayerInteract;
    public float InteractDistance = 2.5f;
    static public List<GameObject> InteractableObjects = new List<GameObject>(); //A list over all game objects -Henry
    List<GameObject> objectsToInteract = new List<GameObject>(); //An interchanging list over all nearby interactable game objects -Henry

    private void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //When scene is loaded, all game objects with interactable tag is added to list -Henry
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
        if (!controlLocked)
        {
            foreach (GameObject curObj in InteractableObjects)
            {
                /*If distance between an object and the player is less than the interact distance, the object is added to a seperate list which will be used
                to invoke interact with more context after loop. -Henry*/
                if (Vector3.Distance(curObj.transform.position, this.transform.position) < InteractDistance)
                {
                    objectsToInteract.Add(curObj);
                }
            }

            //If there is a single game object found in the list, it is used as the object for the interact invoke and then removed from the object list. -Henry
            if (objectsToInteract.Count == 1)
            {
                PlayerInteract?.Invoke(this.gameObject, objectsToInteract[0]);
                objectsToInteract.Remove(objectsToInteract[0]);
            }

            /*If there are multiple objects in the object list, the objects are sorted so that the closest object becomes the first element, then
            the first element on the list is invoked and all interactable objects in object list are removed. -Henry */
            else if (objectsToInteract.Count > 1)
            {
                objectsToInteract.Sort(delegate (GameObject gameObject1, GameObject gameObject2)
                {
                    return Vector3.Distance(gameObject1.transform.position, this.transform.position).CompareTo(Vector3.Distance(gameObject2.transform.position, this.transform.position));
                });
                PlayerInteract?.Invoke(this.gameObject, objectsToInteract[0]);
                objectsToInteract.RemoveAll(x => x.CompareTag("Interactable"));
            }

            //If there is no (or somehow -1) objects in the object list, a debug log is made stating that no objects were found nearby. -Henry
            else
            {
                Debug.Log(this.gameObject.name + " found no object to interact with.");
            }
        }
    }

    public void LockInteract()
    {
        if (controlLocked) controlLocked = false;
        else controlLocked = true;
    }
#if UNITY_EDITOR

    //Fixed update that makes lines to all interactable objects and turns the lines green if a player is interact distance with them. -Henry
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
