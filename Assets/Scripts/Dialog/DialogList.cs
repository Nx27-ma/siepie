using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class DialogList
{
  public static Dictionary<string, List<DialogContainer>> CharacterDictionary = new();
  public static List<DialogContainer> NewlyAddedDialogData = new();
  public static List<DialogContainer> CurrentDialogData = new();
  public static List<TextAsset> CharacterJsons = new();
}
