using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DialogDisplay : MonoBehaviour, IDialog
{
  public static TextAsset textAsset;
  void Start()
  {
    JsonDialogReader.UpdateDialogSet(0);
    PlayerInteraction.InteractPressed += newDialogRequest;
  }

  void newDialogRequest(GameObject player, GameObject npc)
  {
    int npcSeq = npc.GetComponent<NpcDialogSequence>().sequenceNumber;

  }
}
