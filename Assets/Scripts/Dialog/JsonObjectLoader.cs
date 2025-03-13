using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;
using static Dialog.CharacterDialogContainer;

namespace Dialog
{
  public static class JsonObjectLoader
  {
    static List<DialogContainer> DialogFromJson = new();
    static TextAsset JsonFile;
    public static void LoadCharacters()
    {
      JsonFile = Resources.Load<TextAsset>("DialogData/Characters/TheCharacterFile");
      if (JsonFile == null) Debug.LogError("No JSON file found in DialogData/Characters");
      DialogFromJson.Clear();
      var dialogContainer = JsonConvert.DeserializeObject<DialogContainer[]>(JsonFile.text);
      DialogFromJson.Add(dialogContainer[0]);
      Debug.Log("DialogContainer: " + dialogContainer[0].Character);

    }
  }
}
