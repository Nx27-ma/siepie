using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using static Dialog.CharacterDialogContainer;

namespace Dialog
{
  public static class JsonObjectLoader
  {
    static List<DialogContainer> DialogFromJson = new();
    static TextAsset[] JsonFiles;
    public static void LoadCharacters()
    {
      JsonFiles = Resources.LoadAll<TextAsset>("DialogData/Characters");
      if (JsonFiles.Length == 0) Debug.LogError("No JSON files found in DialogData/Characters"); 
      DialogFromJson.Clear();
      foreach (var jsonFile in JsonFiles)
      {
        var dialogContainer = JsonConvert.DeserializeObject<DialogContainer>(jsonFile.text);
        DialogFromJson.Add(dialogContainer);
        Debug.Log("DialogContainer: " + dialogContainer.Character);
      }
    }
  }
}
