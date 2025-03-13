using Dialog;
using static Dialog.CharacterDialogContainer;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterConstructorUI : EditorWindow
{
  [SerializeField] VisualTreeAsset VisualTreeAsset;
  VisualElement root;
  [MenuItem("Window/Character Constructor")]
  private static void MakeGUIAppear()
  {
    GetWindow<CharacterConstructorUI>("Character Dialog");
  }
  void OnEnable()
  {
    root = rootVisualElement;
    UIInitialize();
  }

  public void OnInspectorUpdate()
  {
    Repaint();
  }

  void UIInitialize()
  {
    root.Clear();
    DialogContainerContainer.Add(new DialogContainer() { Character = "sup" });
    VisualElement characterUI = VisualTreeAsset.CloneTree();
    characterUI.SetCharacterUI(DialogContainerContainer[0]);
    root.Add(VisualTreeAsset.CloneTree());
    root[0].SetCharacterUI(DialogContainerContainer[0]);
    root.Add(characterUI);
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
