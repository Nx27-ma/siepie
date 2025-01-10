using JetBrains.Annotations;
using System.Collections.Generic;
using System.Text;
using UnityEngine;


public class JsonDialogReader : ScriptableObject, IDialog
{
  static TextAsset[] allLoadedJsonFiles;
  public static void UpdateDialogSet(int UID)
  {
    if (allLoadedJsonFiles == null)
    {
      allLoadedJsonFiles = Resources.LoadAll<TextAsset>("DialogData");
    }

    List<DialogContainer> allDialogContainers = new();
    foreach (TextAsset asset in allLoadedJsonFiles)
    {
      allDialogContainers.Add(JsonUtility.FromJson<DialogContainer>(asset.text));
    }

    DialogString.OrderDialogContainers(allDialogContainers);
  }

  [System.Serializable]
  public class DialogContainer
  {
    public int UID;
    public int Sequence;
    public string Character;
    public string Dialog;
  }
}
