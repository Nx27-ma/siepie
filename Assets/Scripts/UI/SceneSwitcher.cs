using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class SceneSwitcher : MonoBehaviour
{
    bool OnStart = true;
    public GameObject TextUp, TextDown;
    public Vector2 moveValue;
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

    public void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
        if(moveValue.y < 0)
        {
            OnStart = false;
            TextUp.SetActive(false);
            TextDown.SetActive(true);
        }
        else if (moveValue.y > 0)
        {
            OnStart = true;
            TextUp.SetActive(true);
            TextDown.SetActive(false);
        }
    }

    public void OnInteract()
    {
        if (OnStart)
        {
            OnStartPressed();
        }
        else
        {
            ApplicationQuitPressed();
        }
    }
}
