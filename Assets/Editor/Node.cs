using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class Node 
{
  public Rect NodeBox;
  public string NodeTitle;
  public Node(Vector2 initPos, float initWidth, float initHeight)
  {
    NodeBox = new(initPos.x, initPos.y, initWidth, initHeight);
  }

  public void DraggingNode(Vector2 updatedPos)
  {
    NodeBox.position = updatedPos;
  }

  public void UpdateBox()
  {
    GUI.Box(NodeBox, NodeTitle);
  }
}
