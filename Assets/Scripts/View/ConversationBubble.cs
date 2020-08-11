using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ConversationBubble : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI bubbleText;

    [SerializeField]
    private Image image;

    public void SetText(string text)
    {
        bubbleText.SetText(text);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, ((RectTransform)image.transform).rect.height + 5);
        image.rectTransform.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, ((RectTransform)image.transform).rect.width + 5);
    }
}
