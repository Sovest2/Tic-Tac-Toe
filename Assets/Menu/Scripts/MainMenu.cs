using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenu : MonoBehaviour
{
    [SerializeField] GameObject settingsMenu;

    public void OpenSettings()
    {
        Instantiate(settingsMenu, transform);
    }

    public void StartGame()
    {
        LoadingScreen.LoadScene("Game");
    }

    public void CloseGame()
    {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #elif UNITY_STANDALONE
            Application.Quit();
        #endif
    }
}
