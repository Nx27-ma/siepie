using UnityEngine;

public class DeserializeContainers : MonoBehaviour
{

  void Start()
  {

  }

  public static void WriteToJson()
  {
    foreach (DialogContainer dialogContainer in DialogList.DeserializableDialogList)
    {
      
    }

    JsonUtility.ToJson(typeof(DialogContainer));


  }
}
