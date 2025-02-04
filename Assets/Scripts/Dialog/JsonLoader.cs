using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using static Dialog.DialogList;

//DATAPATH FOR CREATING JSON FILES IS NOT TUNED FOR WEB YET
namespace Dialog
{
  public static class JsonLoader
  {
    static DirectoryInfo directory;
    static string pathToJsonFiles = string.Empty;
    static string[] currentJsonFilesNames;
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
      FileInfo[] fileInfos;
      List<string> fileNamesWithoutExtension = new();

      pathToJsonFiles = Application.dataPath;
      directory = new DirectoryInfo(pathToJsonFiles);

      LoadAssetsFromJson(); //Making sure that its the most up to date version in case the file has been edited by hand
      AddToCharacterDict(NewlyAddedDialogData);

      fileInfos = directory.GetFiles("*.json", SearchOption.AllDirectories);

      foreach (FileInfo info in fileInfos)
      {
        fileNamesWithoutExtension.Add(Path.GetFileNameWithoutExtension(info.FullName));
      }

      foreach (string key in CharacterDictionary.Keys)
      {
        if (fileNamesWithoutExtension.Contains(key))
        {

        }
      }
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
}