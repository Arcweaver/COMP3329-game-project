using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIManager : MonoBehaviour
{
    public enum UIName
    {
        MainMenu,
        LevelSelector,
        CustomizationMenu,
        Tutorial
    }

    public List<GameObject> uiCanvases; 

    void Start()
    {
        ShowSpecificUI("MainMenu"); 
    }


    // Method to show a specific UI
    public void ShowSpecificUI(string uiNameString)
    {
        UIName uiName = (UIName)System.Enum.Parse(typeof(UIName), uiNameString);

        // Hide all canvases
        foreach (var canvas in uiCanvases)
        {
            canvas.SetActive(false);
        }

        // Show the selected canvas
        switch (uiName)
        {
            case UIName.MainMenu:
                uiCanvases[(int)UIName.MainMenu].SetActive(true);
                break;
            case UIName.LevelSelector:
                uiCanvases[(int)UIName.LevelSelector].SetActive(true);
                break;
            case UIName.CustomizationMenu:
                uiCanvases[(int)UIName.CustomizationMenu].SetActive(true);
                break;
            case UIName.Tutorial:
                uiCanvases[(int)UIName.Tutorial].SetActive(true);
                break;
        }
    }

    public void StartGame(string sceneName)
    {
        // Load the selected level
        SceneManager.LoadScene(sceneName);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited"); 
    }
}