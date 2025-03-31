using Dialog;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public static class UIHelper
{
  public static VisualElement GetChildElementByName(this VisualElement view, string name)
  {
    VisualElement queryReq = view.Query<VisualElement>(name).First();
    if (queryReq == null) { Debug.LogError($"No element found with the name \"{name}\""); }

    return queryReq;
  }
  //public static VisualElement SetUIToDialogContainer(this VisualElement view, DialogContainer dc)
  //{
  //  view.GetChildElementByName("FirstFoldout").
  //}

}
