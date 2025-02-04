using UnityEngine;

namespace Dialog
{
  public static class DialogDisplay
  {
    public static TextAsset textAsset;
    static DialogDisplay()
    {

    }
    static void newDialogRequest(GameObject player, GameObject npc)
    {
      int npcSeq = npc.GetComponent<NpcDialogSequence>().sequenceNumber;

    }
  }
}