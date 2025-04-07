using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadGameScene()
    {
        SceneManager.LoadScene("Level1"); // Replace "GameScene" with the name of your real game scene.
    }

    public void LoadStorylineScene()
    {
        SceneManager.LoadScene("StorylineScene"); // Replace "GameScene" with the name of your real game scene.
    }
}