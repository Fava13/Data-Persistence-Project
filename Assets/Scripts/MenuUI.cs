using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class MenuUI : MonoBehaviour
{
    public static MainManager2 Instance;
    public string NameChosen;
    public string PlayerName;

    public void NewPlayerName(string name)
    {
        MainManager2.Instance.PlayerName = name;
    }


    public void StartNew()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
        MainManager2.Instance.save();
    }
}
