using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
  public static class ScriptableObjectLoader
  {
    static List<CharacterDialogContainer> DialogFromJson = new();
    static CharacterDialogContainer[] dialogContainers;

    public static void LoadCharacters()
    {
      dialogContainers = Resources.LoadAll<CharacterDialogContainer>("DialogData/Characters");
      DialogFromJson.Clear();
      foreach (CharacterDialogContainer dialogContainer in dialogContainers)
      {
        DialogFromJson.Add(dialogContainer);
        Debug.Log("DialogContainer: " + dialogContainer.name);
      }
    }
  }
}
