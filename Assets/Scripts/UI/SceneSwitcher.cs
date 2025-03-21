using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
   public static void OnStartPressed()
  {
    SceneManager.LoadScene("Stockholm");
  }

  public static void ApplicationQuitPressed()
  {
    Application.Quit();
  }

  public static void GameFinished()
  {
    SceneManager.LoadScene("Main Menu");
  }
}
