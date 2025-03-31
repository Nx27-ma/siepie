using System.Linq;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UIElements;

namespace Dialog.Game
{
  public class UIDialogUpdater : MonoBehaviour
  {
    public UIDocument uiDocument;
    static Label characterName;
    static Label dialogText;
    static VisualElement characterImage;

    void Start()
    {
      print("UIDialogUpdater Start");
      uiDocument = gameObject.GetComponent<UIDocument>();
      if (uiDocument == null)
      {
        Debug.LogError("UIDocument not found");
        return;
      }
      var root = uiDocument.rootVisualElement;
      characterName = root.Query<Label>("CharacterName");
      if (characterName == null)
      {
        Debug.LogError("CharacterName not found");
        return;
      }
      dialogText = root.Query<Label>("DialogText");
      characterImage = root.Query<VisualElement>("CharacterImage");
      UpdateDialog(JsonObjectLoader.LoadCharacters().First());
    }

    public static void UpdateDialog(DialogContainer dialogContainer)
    {
      characterName.text = "text";
      dialogText.text = dialogContainer.Dialog;


      //if (dialogContainer.Character != "Siepie" && dialogContainer.Character != "Takkie")
      //{
      //  dialogText.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(dialogContainer.CharacterImage));
      //}
      //else
      //{
      //  dialogText.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(dialogContainer.DialogBox));
      //}


      //  characterImage.style.backgroundImage = new StyleBackground(Resources.Load<Sprite>(dialogContainer.DialogBox));
    }
  }
}
