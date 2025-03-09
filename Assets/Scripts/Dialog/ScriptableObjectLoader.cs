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
      DialogFromJson.Clear();
      foreach (DialogContainer dialogContainer in DialogContainerContainer)
      {
        DialogFromJson.Add(dialogContainer);
        Debug.Log("DialogContainer: " + dialogContainer.Character);
      }
    }
  }
}
