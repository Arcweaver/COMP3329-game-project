using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CompletionUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;  // Displays "Game Over!" or "Victory!"
    public TextMeshProUGUI storylineText; // Displays storyline (only for victory)
    public Button actionButton;  // One button (either Proceed or Return)
    public TextMeshProUGUI actionButtonText; // Text inside the button

    void Start()
    {
        // Retrieve win/loss status from PlayerPrefs
        bool playerWon = PlayerPrefs.GetInt("PlayerWon", 0) == 1;

        // Example storyline
        string storyline = "After this battle, you move forward to the next challenge...";

        // Check if it's the final level
        bool isFinalLevel = SceneManager.GetActiveScene().buildIndex == SceneManager.sceneCountInBuildSettings - 1;

        SetupCompletionScreen(playerWon, isFinalLevel, storyline);
    }

    void SetupCompletionScreen(bool playerWon, bool isFinalLevel, string storyline)
    {
        if (playerWon)
        {
            messageText.text = "Victory!";
            storylineText.text = storyline;
            storylineText.gameObject.SetActive(true);  // Show storyline

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
            storylineText.gameObject.SetActive(false);  // Hide storyline

            actionButtonText.text = "Return to Menu";
            actionButton.onClick.AddListener(ReturnToMainMenu);
        }
    }

    void ProceedToNextLevel()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
