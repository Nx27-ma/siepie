using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
  [CreateAssetMenu(fileName = "CharacterDialogContainer", menuName = "ScriptableObjects/DialogContainer", order = 1)]

  public class CharacterDialogContainer : ScriptableObject
  {
    public List<DialogContainer> DialogContainerContainer;
  }


  public class DialogContainer
  {
    public int UID; //DialogSet identifier 
    public int Sequence;
    public string Character;
    public string Dialog;
    public AudioClip AudioClip;
    public float DialogSpeed;
    public float DialogSoundVolume;
  }
}