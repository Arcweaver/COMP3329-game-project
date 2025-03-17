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


public class TextAutoScroll : MonoBehaviour
{
    public float scrollSpeed = 10f; // Speed of scrolling
    public float resetPositionY = -100f; // The position to reset the text
    public float startPositionY = 500f; // The position to start scrolling again  //depend on the length of story
    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Move the text upward
        rectTransform.anchoredPosition += Vector2.up * scrollSpeed * Time.deltaTime;

        // Check if the text is out of view, if so, reset its position
        if (rectTransform.anchoredPosition.y >= startPositionY)
        {
            rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x, resetPositionY);
        }
    }
}