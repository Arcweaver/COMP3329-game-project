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
        CustomizationMenu
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
        }
    }

    public void StartGame(int levelIndex)
    {
        // Load the selected level
        SceneManager.LoadScene(levelIndex);
    }

    public void ExitGame()
    {
        Application.Quit();
        Debug.Log("Game Exited"); 
    }
}