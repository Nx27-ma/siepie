using Dialog;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterConstructorUI : EditorWindow
{
  [SerializeField] VisualTreeAsset UIDSorted;
  [SerializeField] VisualTreeAsset CharacterSorted;
  [SerializeField] VisualTreeAsset SortingChoice;

  static DialogContainer[] DialogContainers;

  [MenuItem("Window/Character Constructor")]
  private static void MakeGUIAppear()
  {
    GetWindow<CharacterConstructorUI>("Character Dialog");
    DialogContainers = Dialog.JsonObjectLoader.LoadCharacters();
  }
  void OnEnable()
  {
    UIInitialize();
  }

  public void OnInspectorUpdate()
  {
    Repaint();
  }

  void UIInitialize()
  {
    rootVisualElement.Clear();
    rootVisualElement.Add(SortingChoice.CloneTree());

    foreach (var dc in DialogContainers)
    {
      var character = CharacterSorted.CloneTree();
      rootVisualElement.Add(character);
      character.SetCharacterUI(dc);
    }
  }

  class WrappedDialogContainer
  {
    WrappedDialogContainer(DialogContainer dc, VisualElement ve)
    {
      DialogContainer = dc;
      VisualElement = ve;
      VisualElement.SetCharacterUI(dc);
    }
    DialogContainer DialogContainer;
    VisualElement VisualElement;
  }

}
public static class CharacterConstructorUIHelper
{
  public static void SetCharacterUI(this VisualElement view, DialogContainer dc) 
  {
    Foldout characterNameVar = view.GetChildElementByName("CharacterName") as Foldout;
    characterNameVar.text = dc.Character ??= "";
    Foldout characterImagesVar = view.GetChildElementByName("CharacterImage") as Foldout;
    characterImagesVar.text = dc.CharacterImage ??= "";
    Foldout characterDialogText = view.GetChildElementByName("CharacterDialog") as Foldout;
    characterDialogText.text = dc.Dialog ??= "";
    Foldout characterVoice = view.GetChildElementByName("CharacterVoice") as Foldout;
    characterVoice.text = dc.AudioClip ??= "";
  }


  static VisualElement GetChildElementByName(this VisualElement view, string name)
  {
    VisualElement queryReq = view.Query<VisualElement>(name).First();
    if (queryReq == null) { Debug.LogError($"No element found with the name \"{name}\""); };
    return queryReq;
  }
}

