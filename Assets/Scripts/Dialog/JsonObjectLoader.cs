using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Dialog
{
  public static class JsonObjectLoader
  {
    static TextAsset JsonFile;
    public static List<DialogContainer> LoadCharacters()
    {
      List<DialogContainer> DialogFromJson = new();
      JsonFile = Resources.Load<TextAsset>("DialogData/Characters/TheCharacterFile");

      if (JsonFile == null) Debug.LogError("No JSON file found in DialogData/Characters");

      DialogFromJson.Clear();

      var dialogContainer = JsonConvert.DeserializeObject<DialogContainer[]>(JsonFile.text);

      DialogFromJson.AddRange(dialogContainer);

      Debug.Log($"DialogContainers in {DialogFromJson}: " + dialogContainer.Length);

      return DialogFromJson;
    }

    public static void SerializeCharacters(DialogContainer[] dcs)
    {
      var jsonInput = JsonConvert.SerializeObject(dcs);
      string path = Path.Combine(Application.dataPath, "Resources/DialogData/Characters/TheCharacterFile.json");

      File.WriteAllText(path, jsonInput);

      Debug.Log($"Serialized {dcs.Length} DialogContainers to {path}");
    }
  }
}
