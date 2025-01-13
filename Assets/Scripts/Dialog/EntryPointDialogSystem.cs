using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;
//using Assembly = UnityEditor.Compilation.Assembly;

//reflection for instantiating all necessary dialog scripts
public class EntryPointDialogSystem : MonoBehaviour
{
  public static List<IDialog> InitList;
  public Type InterfaceType = typeof(IDialog);
  private void Start()
  {
    foreach (Type type in Assembly.GetExecutingAssembly().Modules.First().GetTypes())
    {
      if (type.GetInterface(InterfaceType.ToString()) != null && type.IsSubclassOf(typeof(ScriptableObject)))
      {
        InitList.Add(ScriptableObject.CreateInstance(type) as IDialog);
      }
      else if (type.GetInterface(InterfaceType.ToString()) != null)
      {

      }
    }
  }
}

