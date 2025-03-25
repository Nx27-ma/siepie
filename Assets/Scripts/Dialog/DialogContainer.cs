using System.Collections.Generic;

namespace Dialog
{ 
  [System.Serializable]
  public class DialogContainer
  {
    public byte UID; //DialogSet identifier 
    public byte Sequence;
    public string Character;
    public string Dialog;
    public string AudioClip;
    public byte DialogSpeed;
    public byte DialogSoundVolume;
    public string CharacterImage;
  }
}