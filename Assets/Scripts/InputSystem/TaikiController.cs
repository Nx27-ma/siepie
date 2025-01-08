using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TaikiController : MonoBehaviour
{
    [SerializeField]
    InputActionAsset TaikiControls;
    InputAction move;
    InputAction interact;

    private void OnEnable()
    {
        
    }
}
