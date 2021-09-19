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
    private InputField inputBox;

    private void Start()
    {
        inputBox = GameObject.FindObjectOfType<InputField>();

        inputBox.text = DataMangler.Instance.PlayerName;
    }


    public void Exit()
    {
        DataMangler.Instance.SaveScore();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }


    public void StartNew()
    {
        // Grab the name, and stuff it into the data mangler
        DataMangler.Instance.PlayerName = inputBox.text;

        // Load the main schene
        SceneManager.LoadScene(1);
    }
}
