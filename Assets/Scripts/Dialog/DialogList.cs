using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
  public class DialogList
  {
    public static Dictionary<string, List<DialogContainer>> CharacterDictionary = new();
    public static List<DialogContainer> NewlyAddedDialogData = new();
    public static List<DialogContainer> CurrentDialogData = new();
    public static List<TextAsset> CharacterJsons = new();
  }
}