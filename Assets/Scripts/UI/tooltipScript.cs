using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class Tooltip : MonoBehaviour
{
    void Update()
    {
        // Make the tooltip follows the mouse and change the pivot so it wont go out of screen
        Vector2 mousePosition = Input.mousePosition;

        //float pivotX = mousePosition.x / Screen.width;
        //float pivotY = mousePosition.y / Screen.height;
        //gameObject.GetComponent<RectTransform>().pivot = new Vector2(pivotX, pivotY);

        transform.position = mousePosition;
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void SetHeader(string text)
    {
        TMP_Text header = transform.GetChild(0).gameObject.GetComponent<TMP_Text>();
        header.text = text;
    }
    
    public void SetDescription(string text)
    {
        TMP_Text description = transform.GetChild(1).gameObject.GetComponent<TMP_Text>();
        description.text = text;
    }
}
