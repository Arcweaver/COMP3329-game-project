using UnityEngine;
using TMPro;

public class GameObjectiveTracker : MonoBehaviour
{
    public TextMeshProUGUI objectivesText; // Text UI for displaying objectives
    public int playerHits = 0;            // Count the number of times the player hits the boss
    //public float playerHP = 100f;         // Player's current HP
    //public float maxPlayerHP = 100f;      // Player's max HP for display
    public UnitTemplate player;

    void Start()
    {
        // Reset counters at the start of the level
        playerHits = 0;
        //playerHP = maxPlayerHP;
        UpdateObjectiveText();
    }

    // Call this when the player hits the boss
    public void PlayerHitsBoss()
    {
        playerHits++;
        UpdateObjectiveText();
        SaveObjectives(); // Save data whenever it changes
        Debug.Log($"Player hits boss! Total hits: {playerHits}"); // Debug to confirm
    }

    public void PlayerTakesDamage(float damage)
    {
        //playerHP -= damage;
        //if (playerHP < 0) playerHP = 0; // Clamp HP to 0
        UpdateObjectiveText();
        SaveObjectives(); // Save data whenever it changes
        //Debug.Log($"Player took {damage} damage. HP: {playerHP}"); // Debug to confirm
    }

    // Update the text showing the current objectives
    private void UpdateObjectiveText()
    {
        if (objectivesText != null)
        {
            objectivesText.text = ParseObjectiveText();
        }
    }

    private void SaveObjectives()
    {
        // Prepare the objectives result string, each on its own line
        string resultInfo = ParseObjectiveText();
        PlayerPrefs.SetString("LevelResult", resultInfo);
        PlayerPrefs.Save(); // Ensure data is written to disk
        Debug.Log($"Saved objectives: {resultInfo}"); // Debug to confirm save
    }

    // Public method to force save before level end
    public void SaveObjectivesBeforeLevelEnd()
    {
        SaveObjectives();
    }

    //objective text to be overriden
    public virtual string ParseObjectiveText()
    {
        return $"Player Hits: {playerHits}\nPlayer HP: {player.currentHealth}/{player.maxHealth}";
    }
}
