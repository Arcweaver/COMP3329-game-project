using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CompletionUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;  // Displays "Game Over!" or "Victory!"
    public TextMeshProUGUI resultText; // Displays results & objectives achieved
    public Button actionButton;  // One button (either Proceed or Return)
    public TextMeshProUGUI actionButtonText; // Text inside the button

    void Start()
    {
        // Retrieve win/loss status from PlayerPrefs
        bool playerWon =PlayerPrefs.GetInt("PlayerWon") == 1;

        // Retrieve the result & objectives achieved
        string resultInfo = PlayerPrefs.GetString("LevelResult", "No objectives recorded");

        // Check if it's the final level
        bool isFinalLevel = SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1;
    
        SetupCompletionScreen(playerWon, isFinalLevel, resultInfo);
    }

    void SetupCompletionScreen(bool playerWon, bool isFinalLevel, string resultInfo)
    {
        actionButton.onClick.RemoveAllListeners();

        if (playerWon)
        {
            messageText.text = "Victory!";
            resultText.text = resultInfo; // Display objectives, each on its own line
            resultText.gameObject.SetActive(true);

            if (isFinalLevel)
            {
                actionButtonText.text = "Return to Menu";
                actionButton.onClick.AddListener(ReturnToMainMenu);
            }
            else
            {
                actionButtonText.text = "Next Level";
                actionButton.onClick.AddListener(ProceedToNextLevel);
            }
        }
        else
        {
            messageText.text = "Game Over!";
            resultText.text = resultInfo; // Display objectives, each on its own line
            resultText.gameObject.SetActive(true);

            actionButtonText.text = "Return to Menu";
            actionButton.onClick.AddListener(ReturnToMainMenu);
        }

        actionButton.gameObject.SetActive(true);
    }

    void ProceedToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        string nextSceneName = "Level" + nextSceneIndex;
        SceneManager.LoadScene(nextSceneName);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
