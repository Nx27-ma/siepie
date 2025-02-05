using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class DialogUnityUI : EditorWindow
{
  [SerializeField]
  private VisualTreeAsset m_VisualTreeAsset = default;
  List<string> foldoutNames = new List<string>();


  [MenuItem("Window/DialogUnityUI")]
  public static void ShowExample()
  {
    DialogUnityUI wnd = GetWindow<DialogUnityUI>();
    wnd.titleContent = new GUIContent("DialogUnityUI");
  }

  public void CreateGUI()
  {
    // Each editor window contains a root VisualElement object
    VisualElement root = rootVisualElement;

    // Instantiate UXML
    VisualElement labelFromUXML = m_VisualTreeAsset.Instantiate();
    root.Add(labelFromUXML);


    ListView namesListView = root.Query<ListView>("DataContainerUXML");
    Foldout foldout = new();
    foldout.text = "name";
    foldoutNames.Add(foldout.name);
    namesListView.itemsSource = foldoutNames;
    //namesListView.bindItem
    root.Add(namesListView);
    

  }
}
