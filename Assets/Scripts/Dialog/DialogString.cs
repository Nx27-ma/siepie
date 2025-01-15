using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using System.Linq;

public class DialogString : ScriptableObject, IDialog
{
  static SortedList<int, DialogContainer> orderedDialogList;
  public static void OrderDialogContainers(List<DialogContainer> dialogContainers)
  {
    foreach (DialogContainer dialogContainer in dialogContainers)
    {
      orderedDialogList.Add(dialogContainer.Sequence, dialogContainer);
    }
  }
  public static List<string> GetAllStrings()
  {
    return orderedDialogList.Values.Select(dialog => dialog.Dialog).ToList();
  }
}
