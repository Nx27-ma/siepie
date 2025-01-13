using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class JsonDialogReader : ScriptableObject
{
  static TextAsset[] allLoadedJsonFiles;
  public static void UpdateDialogSet(int UID)
  {
    if (allLoadedJsonFiles == null)
    {
      allLoadedJsonFiles = Resources.LoadAll<TextAsset>("DialogData");
    }
    Debug.Log(allLoadedJsonFiles.Length);
    List<DialogContainer> allDialogContainers = new();
    foreach (TextAsset asset in allLoadedJsonFiles)
    {
      allDialogContainers.Add(JsonUtility.FromJson<DialogContainer>(asset.text));
    }

    DialogString.getCurrentDialogSet(allDialogContainers);
  //  DialogLines = orderDialogStrings();
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
    public int Sequence;
    public string Character;
    public string Dialog;
  }
}
