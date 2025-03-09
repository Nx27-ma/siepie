using Dialog;
using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
using Newtonsoft.Json;
using System.Linq;
using Unity.VisualScripting;

public class CharacterConstructorUI : EditorWindow
{
  [SerializeField] VisualTreeAsset VisualTreeAsset;
  [SerializeField] List<DialogContainer> characterDialogContainer = new();
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
    characterDialogContainer.Add(new DialogContainer() { Character = "sup" });
    VisualElement characterUI = VisualTreeAsset.CloneTree();
    characterUI.SetCharacterUI(characterDialogContainer[0]);
    root.Add(VisualTreeAsset.CloneTree());
    root[0].SetCharacterUI(characterDialogContainer[0]);
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
    characterImagesVar.text = dc.CharacterImage.name ??= "";
    Foldout characterDialogText = view.GetChildElementByName("CharacterDialog") as Foldout;
    characterDialogText.text = dc.Dialog ??= "";
    Foldout characterVoice = view.GetChildElementByName("CharacterVoice") as Foldout;
    characterVoice.text = dc.AudioClip.name ??= "";
  }


  static VisualElement GetChildElementByName(this VisualElement view, string name)
  {
    VisualElement queryReq = view.Query<VisualElement>(name).First();
    if (queryReq == null) { Debug.LogError($"No element found with the name \"{name}\""); };
    return queryReq;
  }
}
