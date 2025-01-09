using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogDisplay : MonoBehaviour
{
  public static TextAsset textAsset;
  void Start()
  {
    JsonDialogReader.UpdateDialogSet(0);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
