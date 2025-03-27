using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Utils;

public class Tempentry : MonoBehaviour
{
  void Start()
  {
    string path = "DialogData/Characters/TheCharacterFile";
    print(path.CutPath("DialogData", false));
  }

  void Update()
  {

  }
}
