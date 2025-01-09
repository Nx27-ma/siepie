using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class JsonDialogReader : ScriptableObject
{
  public static List<string> DialogLines { get; private set; }
  public static void UpdateDialogSet(int UID)
  {
    TextAsset[] allLoadedJsonFiles = Resources.LoadAll<TextAsset>("DialogData");
    Debug.Log(allLoadedJsonFiles.Length);
    List<DialogContainer> allDialogContainers = new();
    foreach (TextAsset asset in allLoadedJsonFiles)
    {
      allDialogContainers.Add(JsonUtility.FromJson<DialogContainer>(asset.text));
    }

    getCurrentDialogSet(allDialogContainers);
  //  DialogLines = orderDialogStrings();
  }

  static void getCurrentDialogSet(List<DialogContainer> dialogContainers)
  {
    StringBuilder tempDialog = new();
    foreach (DialogContainer dialogContainer in dialogContainers)
    {
       tempDialog.Append(dialogContainer.Dialog);
    }
  }
  

  //private static List<string> orderDialogStrings()
  //{
  //  if()
  //  foreach (DialogContainer dialogContainer in CurrentDialogContainers)
  //  {
      
  //  }
  //  return 
  //}


  [System.Serializable]
  public class DialogContainer
  {
    public int UID;
    public bool SequenceStarter;
    public string Dialog;
  }
}
