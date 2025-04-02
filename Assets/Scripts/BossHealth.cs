using UnityEngine;
using UnityEngine.SceneManagement;

public class BossHealth : HealthDisplay
{

    public override void HandleGameOver()
    {
        PlayerPrefs.SetInt("PlayerWon", 1); // Player won
        PlayerPrefs.SetString("LevelResult", "You defeated the boss and unlocked a new skill!");
        PlayerPrefs.Save();
        SceneManager.LoadScene("CompletionUI"); // Switch to the victory screen
    }

}
