using UnityEngine;
using UnityEngine.Events;

public class PotatoCheck : MonoBehaviour
{
    public GameObject Potato; // Reference to the Potato GameObject
    public UnityEvent GotPotato;
    private bool HasPotato = false;


    public void Potatocheck(GameObject interactor)
    {
        bool isPotatoActive = Potato.activeSelf;
        
        if (interactor.CompareTag("Cat"))
        {
            if ( HasPotato == false)
            {
                Debug.Log("I  want a yummy Potat");
            }
            else 
            {
                Debug.Log("Thanks for the potato");
            }
        }
        else if (interactor.CompareTag("Human"))
        {
            if (isPotatoActive)
            {
                Debug.Log("Kaaaaaawwwww!");
            }
            else
            {
                Debug.Log("(Happy) Kaaaawww!!!!");
                HasPotato = true;
                GotPotato.Invoke();
            }
        }
    }
}
