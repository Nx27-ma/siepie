using UnityEngine;

public class DeserializeContainers : ScriptableObject
{
  public static TextAsset[] AllCharacterJsons;
  void Start()
  {
    AllCharacterJsons = Resources.LoadAll("DialogData") as TextAsset[];
  }

  public static void WriteToJson()
  {
  }
}
