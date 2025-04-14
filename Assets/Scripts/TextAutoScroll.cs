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
    // Auto scroll
    /*
    public float scrollSpeed = 10f; // Speed of scrolling
    public float resetPositionY = -100f; // The position to reset the text
    //public float startPositionY = 500f; // The position to start scrolling again  //depend on the length of story
    private RectTransform rectTransform;
    private TextMeshProUGUI storyText;
    private float startPositionY; // Dynamically set based on text height
    */

    // Player can control the scroll speed
    public float scrollSensitivity = 100f; // Pixels per scroll tick (adjust in Inspector)
    public float minPositionY = -100f;    // Bottom bound (start of text, off-screen)
    private RectTransform rectTransform;
    private TextMeshProUGUI storyText;
    private float maxPositionY;           // Top bound (end of text)

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
        //startPositionY = resetPositionY + textHeight + 100f; // Add padding
        minPositionY = rectTransform.anchoredPosition.y; // Starting position
        maxPositionY = minPositionY + textHeight + 100f; // End position with padding
    }

    void Update()
    {
        // Get mouse wheel input
        float scrollInput = Input.mouseScrollDelta.y;

        if (scrollInput != 0)
        {
            // Move text based on scroll direction
            float scrollAmount = scrollInput * scrollSensitivity;
            Vector2 newPosition = rectTransform.anchoredPosition + new Vector2(0, scrollAmount);

            // Clamp position to prevent scrolling past bounds
            newPosition.y = Mathf.Clamp(newPosition.y, minPositionY, maxPositionY);
            rectTransform.anchoredPosition = newPosition;
        }

        // Move the text upward
        /*
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Reset position when text scrolls off-screen
        if (rectTransform.anchoredPosition.y >= startPositionY)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, resetPositionY);
        }
        */
    }
}