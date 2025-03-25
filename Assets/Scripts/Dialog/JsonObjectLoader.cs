using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

namespace Dialog
{
  public static class JsonObjectLoader
  {
    static TextAsset JsonFile;
    public static DialogContainer[] LoadCharacters()
    {
      JsonFile = Resources.Load<TextAsset>("DialogData/Characters/TheCharacterFile");

      if (JsonFile == null) Debug.LogError("No JSON file found in DialogData/Characters");

      var dialogContainers = JsonConvert.DeserializeObject<DialogContainer[]>(JsonFile.text);

      Debug.Log($"DialogContainers in {dialogContainers}: " + dialogContainers.Length);

      return dialogContainers;
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
