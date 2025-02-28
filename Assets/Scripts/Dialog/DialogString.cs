using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

namespace Dialog
{
  public class DialogString : ScriptableObject
  {
    static SortedList<int, DialogContainer> orderedDialogList;
   
    public static List<string> GetAllStrings()
    {
      return orderedDialogList.Values.Select(dialog => dialog.Dialog).ToList();
    }
  }
}