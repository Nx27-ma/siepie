using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempentry : MonoBehaviour
{
  void Start()
  {
    Dialog.JsonObjectLoader.LoadCharacters();
  }

  // Update is called once per frame
  void Update()
  {

  }
}
