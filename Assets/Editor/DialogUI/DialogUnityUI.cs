using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Dialog;

public class DialogUnityUI : EditorWindow
{
  [SerializeField]
  private VisualTreeAsset m_VisualTreeAsset = default;


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
  }
}

public class CharacterListEditor
{
  Label highestTree;

  public void PassVisualElement(VisualElement ve)
  {
    highestTree = ve.Q<Label>("HighestTreeLabel");
  }

  public void DisplayCharacterSets(DialogContainer dc)
  {
    highestTree.text = dc.Character;

  }
}

public static class DialogContainerLoader
{

}