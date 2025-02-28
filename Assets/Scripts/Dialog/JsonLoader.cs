using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;


//DATAPATH FOR CREATING JSON FILES IS NOT TUNED FOR WEB YET
namespace Dialog
{
  public static class JsonLoader
  {
    static List<DialogContainer> DialogFromJson = new();
    static TextAsset[] textAssets;
    public static void LoadAssetsFromJson()
    {
      textAssets = Resources.LoadAll<TextAsset>("DialogData");
      DialogFromJson.Clear();
      foreach (TextAsset dialogJson in textAssets)
      {
        DialogFromJson.Add(JsonUtility.FromJson<DialogContainer>(dialogJson.text));
      }
      DialogFromJson.ForEach(x => Debug.Log($"{x.Character} - {x.UID}"));
    }
  }
}
