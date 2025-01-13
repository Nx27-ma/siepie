using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEngine;

//reflection for instantiating all necessary dialog scripts
public class EntryPointDialogSystem : MonoBehaviour
{
  public static EntryPointDialogSystem instance;
  public static List<IDialog> InitList;
  private void Start()
  {
    InitList =  InitAllUnityObjectsFromInterface<IDialog>();
    foreach(IDialog dialog in InitList)
    {
      print(dialog);
    }
    instance = this;
  }
  private List<T> InitAllUnityObjectsFromInterface<T>() where T : class
  {
    List<T> L = new();
    foreach (Type type in Assembly.GetExecutingAssembly().Modules.First().GetTypes())
    {
      if (type.GetInterface(typeof(T).ToString()) != null && type.IsSubclassOf(typeof(ScriptableObject)))
      {
        L.Add(ScriptableObject.CreateInstance(type) as T);
      }
      else if (type.GetInterface(typeof(T).ToString()) != null)
      {
        L.Add(gameObject.AddComponent(type) as T);
      }
    }
    return L;
  }
}

