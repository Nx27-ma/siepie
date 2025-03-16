using UnityEngine;
using UnityEngine.UIElements;

namespace Dialog
{
  public class UIDialogUpdater : MonoBehaviour
  {
    public UIDocument uiDocument;
    private Label characterLabel;
    private Label dialogLabel;
    private Image characterImage;

    void Start()
    {
      var root = uiDocument.rootVisualElement;
      characterLabel = root.Q<Label>("CharacterLabel");
      dialogLabel = root.Q<Label>("DialogLabel");
      characterImage = root.Q<Image>("CharacterImage");
    }

    public void UpdateDialog(DialogContainer dialogContainer)
    {
      characterLabel.text = dialogContainer.Character;
      dialogLabel.text = dialogContainer.Dialog;

      // Assuming you have a method to load a sprite from a resource path
      Sprite sprite = Resources.Load<Sprite>(dialogContainer.CharacterImage);
    }
  }
}
