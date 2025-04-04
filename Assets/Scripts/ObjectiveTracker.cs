using UnityEngine;
using TMPro;

public class GameObjectiveTracker : MonoBehaviour
{
    public TextMeshProUGUI objectivesText; // Text UI for displaying objectives
    public int playerHits = 0;            // Count the number of times the player hits the boss
    public float playerHP = 100f;         // Player's current HP
    public float maxPlayerHP = 100f;      // Player's max HP for display

    void Start()
    {
        // Reset counters at the start of the level
        playerHits = 0;
        playerHP = maxPlayerHP;
        UpdateObjectiveText();
    }

    // Call this when the player hits the boss
    public void PlayerHitsBoss()
    {
        playerHits++;
        UpdateObjectiveText();
        SaveObjectives(); // Save data whenever it changes
    }

    public void PlayerTakesDamage(float damage)
    {
        playerHP -= damage;
        if (playerHP < 0) playerHP = 0; // Clamp HP to 0
        UpdateObjectiveText();
        SaveObjectives(); // Save data whenever it changes
    }

    // Update the text showing the current objectives
    private void UpdateObjectiveText()
    {
        if (objectivesText != null)
        {
            objectivesText.text = $"Player Hits: {playerHits}\nPlayer HP: {playerHP}/{maxPlayerHP}";
        }
    }

    private void SaveObjectives()
    {
        // Prepare the objectives result string, each on its own line
        string resultInfo = $"Player Hits: {playerHits}\nPlayer HP: {playerHP}/{maxPlayerHP}";
        PlayerPrefs.SetString("LevelResult", resultInfo);
        PlayerPrefs.Save(); // Ensure data is written to disk
    }

    // Public method to force save before level end
    public void SaveObjectivesBeforeLevelEnd()
    {
        SaveObjectives();
    }
}
