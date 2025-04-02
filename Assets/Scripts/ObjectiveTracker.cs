using UnityEngine;
using TMPro;

public class GameObjectiveTracker : MonoBehaviour
{
    public TextMeshProUGUI objectivesText; // Text UI for displaying objectives
    public int playerHits = 0;            // Count the number of times the player hits the boss
    public int bossHits = 0;              // Count the number of times the boss hits the player

    void Start()
    {
        UpdateObjectiveText();
    }

    // Call this when the player hits the boss
    public void PlayerHitsBoss()
    {
        playerHits++;
        UpdateObjectiveText();
    }

    // Call this when the boss hits the player
    public void BossHitsPlayer()
    {
        bossHits++;
        UpdateObjectiveText();
    }

    // Update the text showing the current objectives
    private void UpdateObjectiveText()
    {
        if (objectivesText != null)
        {
            objectivesText.text = $"Player Hits: {playerHits}\nBoss Hits: {bossHits}";
        }
    }
}
