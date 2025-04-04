using UnityEngine;
using TMPro;

public class GameObjectiveTracker : MonoBehaviour
{
    public TextMeshProUGUI objectivesText; // Text UI for displaying objectives
    public int playerHits = 0;            // Count the number of times the player hits the boss
    public int bossHits = 0;              // Count the number of times the boss hits the player
    public int hitsToWin = 5;             // Example: Player needs 5 hits to win, should be different in each level
    public int maxBossHitsAllowed = 3;    // Example: Player loses if boss hits them 3 times, should be different in each level

    private bool levelCompleted = false;

    void Start()
    {
        // Reset counters at the start of the level
        playerHits = 0;
        bossHits = 0;
        UpdateObjectiveText();
    }

    // Call this when the player hits the boss
    public void PlayerHitsBoss()
    {
        playerHits++;
        CheckLevelCompletion();
        UpdateObjectiveText();
    }

    // Call this when the boss hits the player
    public void BossHitsPlayer()
    {
        bossHits++;
        CheckLevelCompletion();
        UpdateObjectiveText();
    }

    // Update the text showing the current objectives
    private void UpdateObjectiveText()
    {
        if (objectivesText != null)
        {
            objectivesText.text = $"Player Hits: {playerHits}/{hitsToWin}\nBoss Hits: {bossHits}/{maxBossHitsAllowed}";
        }
    }

    // Check if the level is won or lost
    private void CheckLevelCompletion()
    {
        if (playerHits >= hitsToWin && !levelCompleted)
        {
            levelCompleted = true;
            EndLevel(true); // Player wins
        }
        else if (bossHits >= maxBossHitsAllowed && !levelCompleted)
        {
            levelCompleted = true;
            EndLevel(false); // Player loses
        }
    }

    // Save objectives and end the level
    private void EndLevel(bool playerWon)
    {
        // Save win/loss status
        PlayerPrefs.SetInt("PlayerWon", playerWon ? 1 : 0);

        // Prepare the objectives result string
        string resultInfo = $"Objectives:\n- Hit the boss: {playerHits}/{hitsToWin} ( {(playerHits >= hitsToWin ? "Achieved" : "Failed")} )\n- Avoid boss hits: {bossHits}/{maxBossHitsAllowed} ( {(bossHits < maxBossHitsAllowed ? "Achieved" : "Failed")} )";
        PlayerPrefs.SetString("LevelResult", resultInfo);

        // Load the completion scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("CompletionUI");
    }
}
