using UnityEngine;


public class JsonDialogReader : ScriptableObject
{
  public static DialogContainer RequestDialogSet(TextAsset textAsset)
  {
    string jsonString = textAsset.text;
    return JsonUtility.FromJson<DialogContainer>(jsonString);
  }
  [System.Serializable]
  public class DialogContainer
  {
    public int UID;
    public bool SequenceStarter;
    public string Dialog;
  }
}
