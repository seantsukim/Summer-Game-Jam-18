using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public void ChangeScene(string newScene)
    {
        SceneManager.LoadScene(newScene);
    }

    public void ExitButton()
    {
        Application.Quit();
    }
}
