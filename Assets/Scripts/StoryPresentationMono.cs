using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class StoryPresentationMono : MonoBehaviour
{
    [SerializeField]
    private Canvas _canvas;

    [SerializeField]
    private Transform _container;

    [SerializeField]
    private ConversationBubble _playerConversationBubblePrefab;

    [SerializeField]
    private ConversationBubble _npcConversationBubblePrefab;

    [SerializeField]
    private OptionsPanel _optionsPanel;

    [SerializeField]
    private ScrollRect _scrollView;


    public void CreateTextBubble(string text, bool belongsToPlayer)
    {
        ConversationBubble bubble;

        if (belongsToPlayer)
        {
            bubble = Instantiate(_playerConversationBubblePrefab, _container);
        }
        else
        {
            bubble = Instantiate(_npcConversationBubblePrefab, _container);
        }

        bubble.SetText(text);
        bubble.gameObject.SetActive(true);

        _scrollView.ScrollToBottom();

    }

    public void DisplayOptions(List<Choice> choices)
    {
        _optionsPanel.Show(choices);
    }

    public void HideOptions()
    {
        _optionsPanel.Hide();
    }
}
