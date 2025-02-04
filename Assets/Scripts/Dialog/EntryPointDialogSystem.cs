using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

//reflection for instantiating all necessary dialog scripts
namespace Utils {
  public static class InitThroughReflection
  {
    public static List<T> InitClassWithInterfaceImplementation<T>() where T : class
    {
      List<T> L = new();
      foreach (Type type in Assembly.GetExecutingAssembly().Modules.First().GetTypes())
      {
        if (type.GetInterface(typeof(T).ToString()) != null)
        {
          L.Add(Activator.CreateInstance(type) as T);
        }
      }
      return L;
    }
  }
}