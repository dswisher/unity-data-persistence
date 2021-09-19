using System.Collections;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
#endif

using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuUI : MonoBehaviour
{
    public void Exit()
    {
        // MainManager.Instance.SaveColor();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


    public void StartNew()
    {
        // Grab the name, and stuff it into the data mangler
        var input = GameObject.FindObjectOfType<InputField>();

        DataMangler.Instance.PlayerName = input.text;

        // Load the main schene
        SceneManager.LoadScene(1);
    }
}
