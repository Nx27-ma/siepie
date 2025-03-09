using System.Collections.Generic;
using UnityEngine;

namespace Dialog
{
  public class CharacterDialogContainer
  {
    public static List<DialogContainer> DialogContainerContainer { internal set; get; }
    
  }

  [System.Serializable]
  public class DialogContainer
  {
    public int UID; //DialogSet identifier 
    public int Sequence;
    public string Character;
    public string Dialog;
    public AudioClip AudioClip;
    public float DialogSpeed;
    public float DialogSoundVolume;
    public Sprite CharacterImage;
  }
}