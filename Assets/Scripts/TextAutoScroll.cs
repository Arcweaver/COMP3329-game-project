/*using UnityEngine;
using TMPro;

public class TextAutoScroll : MonoBehaviour
{
    public float scrollSpeed = 10f; // Scrolling speed
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Move the text upward
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;
    }
}
*/

using UnityEngine;
using TMPro;


public class TextAutoScroll : MonoBehaviour
{
    public float scrollSpeed = 10f; // Speed of scrolling
    public float resetPositionY = -100f; // The position to reset the text
    //public float startPositionY = 500f; // The position to start scrolling again  //depend on the length of story
    private RectTransform rectTransform;
    private TextMeshProUGUI storyText;
    private float startPositionY; // Dynamically set based on text height

    // Story content for each level
    [TextArea(3, 10)]
    public string level1Story = "The hero begins their journey...";
    [TextArea(3, 10)]
    public string level2Story = "The hero ventures deeper into the dark forest...";
    [TextArea(3, 10)]
    public string level3Story = "The castle looms ahead, filled with danger...";
    [TextArea(3, 10)]
    public string endingStory = "With the boss defeated, peace returns...";

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        storyText = GetComponent<TextMeshProUGUI>();

        // Determine which story to show
        int nextLevelIndex = PlayerPrefs.GetInt("NextLevelIndex", 1);
        switch (nextLevelIndex)
        {
            case 1:
                storyText.text = level1Story;
                break;
            case 2:
                storyText.text = level2Story;
                break;
            case 3:
                storyText.text = level3Story;
                break;
            default:
                storyText.text = endingStory; // After Level3 or invalid index
                break;
        }

        // Calculate startPositionY based on text height
        storyText.ForceMeshUpdate(); // Ensure text is rendered to get size
        float textHeight = storyText.preferredHeight;
        startPositionY = resetPositionY + textHeight + 100f; // Add padding
    }

    void Update()
    {
        // Move the text upward
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Reset position when text scrolls off-screen
        if (rectTransform.anchoredPosition.y >= startPositionY)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, resetPositionY);
        }
    }
}