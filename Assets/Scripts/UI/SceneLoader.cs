using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    /*
    public void StartGame()
    {
        PlayerPrefs.SetInt("NextLevelIndex", 1); // Set for Level 1
        SceneManager.LoadScene("StorylineScene"); // Load Level 1 story
    }
    */

    public void SelectLevel1()
    {
        PlayerPrefs.SetInt("NextLevelIndex", 1);
        PlayerPrefs.Save();
        Debug.Log("Selected Level 1, loading StorylineScene");
        SceneManager.LoadScene("StorylineScene");
    }

    public void SelectLevel2()
    {
        PlayerPrefs.SetInt("NextLevelIndex", 2);
        PlayerPrefs.Save();
        Debug.Log("Selected Level 2, loading StorylineScene");
        SceneManager.LoadScene("StorylineScene");
    }

    public void SelectLevel3()
    {
        PlayerPrefs.SetInt("NextLevelIndex", 3);
        PlayerPrefs.Save();
        Debug.Log("Selected Level 3, loading StorylineScene");
        SceneManager.LoadScene("StorylineScene");
    }


    public void LoadNextScene()
    {
        int nextLevelIndex = PlayerPrefs.GetInt("NextLevelIndex", 1); // Default to Level1 if not set
        string nextScene;

        if (nextLevelIndex == 1)
        {
            nextScene = "Level1";
        }
        else if (nextLevelIndex == 2)
        {
            nextScene = "Level2";
        }
        else if (nextLevelIndex == 3)
        {
            nextScene = "Level3";
        }
        else
        {
            // Final level completed, return to menu
            nextScene = "GameMenu";
        }

        Debug.Log($"Loading next scene: {nextScene} (NextLevelIndex: {nextLevelIndex})");
        SceneManager.LoadScene(nextScene);
    }

    public void LoadGameMenu()
    {
        SceneManager.LoadScene("GameMenu");
    }
}