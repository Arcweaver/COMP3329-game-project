using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class CompletionUI : MonoBehaviour
{
    public TextMeshProUGUI messageText;  // Displays "Game Over!" or "Victory!"
    public TextMeshProUGUI resultText; // Displays results & objectives achieved
    //public Button actionButton;  // One button (either Proceed or Return)
    //public TextMeshProUGUI actionButtonText; // Text inside the button
    public Button returnToMenuButton;        // Always active
    public TextMeshProUGUI returnToMenuButtonText;
    public Button nextLevelButton;           // Only active on win
    public TextMeshProUGUI nextLevelButtonText; // Text for next level button

    void Start()
    {
        // Retrieve win/loss status from PlayerPrefs
        bool playerWon =PlayerPrefs.GetInt("PlayerWon") == 1;

        // Retrieve the result & objectives achieved
        string resultInfo = PlayerPrefs.GetString("LevelResult", "No objectives recorded");

        // Check if it's the final level
        int previousLevelIndex = PlayerPrefs.GetInt("PreviousLevelIndex", 1); // Default to 1 (Level1)
        bool isFinalLevel = previousLevelIndex == 3; // Level3 is the final level

        Debug.Log($"PlayerWon: {playerWon}, PreviousLevelIndex: {previousLevelIndex}, isFinalLevel: {isFinalLevel}");

        SetupCompletionScreen(playerWon, isFinalLevel, resultInfo);
    }

    void SetupCompletionScreen(bool playerWon, bool isFinalLevel, string resultInfo)
    {
        returnToMenuButton.onClick.RemoveAllListeners();
        if (nextLevelButton != null)
        {
            nextLevelButton.onClick.RemoveAllListeners();
        }

        resultText.text = resultInfo;
        resultText.gameObject.SetActive(true);

        if (playerWon)
        {
            messageText.text = "Victory!";
            returnToMenuButtonText.text = "Return to Menu";
            returnToMenuButton.onClick.AddListener(isFinalLevel ? LoadEndingStory : ReturnToMainMenu);
            returnToMenuButton.gameObject.SetActive(true);
            Debug.Log(isFinalLevel);

            // Show Next Level button unless it's the final level
            if (!isFinalLevel && nextLevelButton != null)
            {
                nextLevelButtonText.text = "Next Level";
                nextLevelButton.onClick.AddListener(ProceedToNextLevel);
                nextLevelButton.gameObject.SetActive(true);
            }
            else if (nextLevelButton != null)
            {
                nextLevelButton.gameObject.SetActive(false); // Hide if final level
                Debug.Log("Next Level button hidden: isFinalLevel = " + isFinalLevel);
            }
        }
        else
        {
            messageText.text = "Game Over!";
            returnToMenuButtonText.text = "Return to Menu";
            returnToMenuButton.onClick.AddListener(ReturnToMainMenu);
            returnToMenuButton.gameObject.SetActive(true);

            if (nextLevelButton != null)
            {
                nextLevelButton.gameObject.SetActive(false);
                Debug.Log("Next Level button hidden: Player lost");
            }
        }
    }

    void ProceedToNextLevel()
    {
        int previousLevelIndex = PlayerPrefs.GetInt("PreviousLevelIndex", 1);
        PlayerPrefs.SetInt("NextLevelIndex", previousLevelIndex + 1); // Next level
        SceneManager.LoadScene("StorylineScene");
    }

    void LoadEndingStory()
    {
        PlayerPrefs.SetInt("NextLevelIndex", 4); // For ending story
        SceneManager.LoadScene("StorylineScene");
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}
