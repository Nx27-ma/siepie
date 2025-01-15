using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

using static DialogList;

//DATAPATH FOR CREATING JSON FILES IS NOT TUNED FOR WEB YET

public class JsonLoader : MonoBehaviour, IDialog
{
  static string pathToJsonFiles;
  public static void LoadAssetsFromJson()
  {
    TextAsset[] textAssets = Resources.LoadAll<TextAsset>("DialogData");
    CharacterJsons = textAssets.ToList();
    foreach (TextAsset dialog in CharacterJsons)
    {
      CurrentDialogData.Add(JsonUtility.FromJson<DialogContainer>(dialog.text));

    }
    AddToCharacterDict(CurrentDialogData);

    foreach (string key in CharacterDictionary.Keys)
    {
      foreach (DialogContainer dialogContainer in CharacterDictionary[key])
      {
        Debug.Log($"{key} , {dialogContainer.Character}");
      }
    }
  }

  public static void WriteUpdateToJson()
  {
    if (pathToJsonFiles == string.Empty)
    {
      pathToJsonFiles = Application.persistentDataPath;
      pathToJsonFiles = Path.Combine(pathToJsonFiles, "Resources/DialogData");
      Debug.Log(pathToJsonFiles);
    }
    LoadAssetsFromJson(); //Making sure that its the most up to date version in case the file has been edited by hand
    AddToCharacterDict(NewlyAddedDialogData);
  }

  static void AddToCharacterDict(List<DialogContainer> dialog)
  {
    foreach (DialogContainer dialogContainer in dialog)
    {
      if (!CharacterDictionary.ContainsKey(dialogContainer.Character))
      {
        CharacterDictionary.Add(dialogContainer.Character, new List<DialogContainer> { dialogContainer });
      }
      else if (CharacterDictionary.ContainsKey(dialogContainer.Character))
      {
        CharacterDictionary[dialogContainer.Character].Add(dialogContainer);
      }
    }
  }
}
