using Dialog;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class CharacterConstructorUI : EditorWindow
{
  static CharacterConstructorUI instance;
 
  [SerializeField] VisualTreeAsset UIDSorted;
  [SerializeField] VisualTreeAsset characterSorted;
  [SerializeField] VisualTreeAsset sortingChoice;
  VisualTreeAsset[] sortingAssets;

  List<WrappedDialogContainer> wrappedDialogContainers;
  DialogContainer[] dialogContainers;
  ScrollView dialogScrollView;

  [MenuItem("Window/Character Constructor")]
  static void InitGUI()
  {
    instance = GetWindow<CharacterConstructorUI>("Character Dialog");
    instance.dialogContainers = Dialog.JsonObjectLoader.LoadCharacters();
    instance.wrappedDialogContainers = new();
    instance.dialogScrollView = new();
    instance.ChoiceInit();
  }

  void ChoiceInit()
  {
    rootVisualElement.Clear();
    
    VisualElement choiceVE = sortingChoice.CloneTree();
    DropdownField choiceDropDownField = choiceVE.Query<DropdownField>("SortingField");

    styles();

    sortingAssets = new VisualTreeAsset[] { UIDSorted, characterSorted };
    choiceDropDownField.choices = sortingAssets.ToList()
      .Select(asset => asset.name).ToList();
    choiceDropDownField.RegisterValueChangedCallback((sort) =>
    {
      Debug.Log("DropdownField value changed to: " + sort.newValue);
      SortBasedOn(sortingAssets.First(x => x.name == sort.newValue));
    });
    rootVisualElement.Add(choiceVE);

  }

  void styles()
  {
    rootVisualElement.style.flexDirection = FlexDirection.Column;
    rootVisualElement.style.height = new StyleLength(new Length(100, LengthUnit.Percent));
    dialogScrollView.style.flexGrow = 1;
    dialogScrollView.style.flexShrink = 1;
    dialogScrollView.style.flexBasis = new StyleLength(new Length(90, LengthUnit.Percent));
  }

  void OnInspectorUpdate()
  {
    Repaint();
  }

  void SortBasedOn(VisualTreeAsset tree)
  {
    dialogScrollView.Clear();
    if (rootVisualElement.Children().Contains(dialogScrollView))
      rootVisualElement.Remove(dialogScrollView);

    foreach (var dc in dialogContainers)
    {
      var VETree = tree.CloneTree();
      wrappedDialogContainers.Add(new WrappedDialogContainer(dc, VETree));
      dialogScrollView.Add(VETree);
    }
    rootVisualElement.Add(dialogScrollView);
  }

  class WrappedDialogContainer
  {
    DialogContainer DialogContainer;
    VisualElement VisualElement;
    internal WrappedDialogContainer(DialogContainer dc, VisualElement ve)
    {
      DialogContainer = dc;
      VisualElement = ve;
    }

    void RegisterElements()
    {

    }

    
  }
}


