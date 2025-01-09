using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogDisplay : MonoBehaviour
{
  public static TextAsset textAsset;
  void Start()
  {
    textAsset = Resources.Load<TextAsset>("DialogData");
    JsonDialogReader.DialogContainer container = JsonDialogReader.RequestDialogSet(textAsset);
    print(container.Dialog);
  }

  // Update is called once per frame
  void Update()
  {

  }
}
