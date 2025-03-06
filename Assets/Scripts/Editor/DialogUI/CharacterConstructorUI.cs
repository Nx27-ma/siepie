using Dialog;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterConstructorUI : EditorWindow
{
  [SerializeField] CharacterDialogContainer container;
  VisualElement root;
  [MenuItem("Window/Character Constructor")]
  private static void MakeGUIAppear()
  {
    GetWindow<CharacterConstructorUI>("Character Dialog");
  }
  void OnEnable()
  {
    root = rootVisualElement;
  }

  public void OnInspectorUpdate()
  {
    Repaint();
  }

  void UIInitialize()
  {
  }
}
public static class CharacterConstructorUIHelper
{
  public static VisualElement BuildCharacterUI(this VisualElement view, string characterName)
  {
    view.Add(new Label("Character Name") { name = "CharacterName" });
    view.Add(new TextField() { name = "CharacterNameTextField" });
    view.Add(new Label("Character Images") { name = "CharacterImages" });
    view.Add(new Button() { name = "CharacterImagesButton" });
    view.Add(new Label("Character Dialog") { name = "CharacterDialog" });
    view.Add(new TextField("CharacterDialogTextField"));
    view.Add(new Label("Character Voice") { name = "CharacterVoice" });
    view.Add(new Button() { name = "CharacterVoiceButton" });
    view.Add(new Label("Character Dialog Speed") { name = "CharacterDialogSpeed" });
    view.Add(new Slider(0.0f, 100f) { value = 0.0f, name = "CharacterDialogSpeedSlider" });
    view.Add(new Label("Character Dialog Sound Volume") { name = "CharacterDialogSoundVolume" });
    view.Add(new Slider(0.0f, 100f) { value = 0.0f, name = "CharacterDialogSoundVolumeSlider" });
    view.Add(new Button() { name = "Save" });
    Foldout foldout = new Foldout { text = characterName };
    foldout.Add(view);
    return foldout;
  }

}
