using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class DialogNodes : EditorWindow
{
  List<Node> nodes;


  [MenuItem("Window/Dialog Nodes")]
  private static void StartWindow()
  {
    DialogNodes dialogNodes = GetWindow<DialogNodes>();
    dialogNodes.titleContent = new GUIContent("DialogEditor");
  }
}
