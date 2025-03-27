using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialog.Game
{
  public class UIDialogUpdater : MonoBehaviour
  {
    public UIDocument uiDocument;
    Label characterName;
    Label dialogText;
    VisualElement characterImage;

    void Start()
    {
      var root = uiDocument.rootVisualElement;
      characterName = root.Query<Label>("CharacterName");
      dialogText = root.Query<Label>("DialogText");
      characterImage = root.Query<VisualElement>("CharacterImage");
    }

    public void UpdateDialog(DialogContainer dialogContainer)
    {
      characterName.text = dialogContainer.Character;
      dialogText.text = dialogContainer.Dialog;
      if (dialogContainer.Character != "Siepie" && dialogContainer.Character != "Takkie")
      {
        dialogText.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(dialogContainer.CharacterImage));
      }
      else
      {
        dialogText.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(dialogContainer.DialogBox));
      }


        characterImage.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(dialogContainer.DialogBox));
    }
  }
}
