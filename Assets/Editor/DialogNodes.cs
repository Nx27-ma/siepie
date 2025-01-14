using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;

public class DialogNodes : EditorWindow
{
  static string myString = "";

  [MenuItem("Window/Dialog Nodes")]
  private static void StartWindow()
  {
    DialogNodes dialogNodes = GetWindow<DialogNodes>();
    dialogNodes.titleContent = new GUIContent("DialogEditor");
  }

  private void OnEnable()
  {
  }
  private void OnGUI()
  {
    GUIStyle GUIStyle = new GUIStyle();
    GUIStyle textfieldStyle = new GUIStyle(GUI.skin.textField);
    textfieldStyle.margin= new RectOffset(10, 10, 10, 10);

    GUIStyle.margin = new RectOffset(10, 10 ,10 ,10);
    

    GUILayout.Label("Base Settings", GUIStyle);
    myString = GUILayout.TextField(myString, textfieldStyle);
  }
}
