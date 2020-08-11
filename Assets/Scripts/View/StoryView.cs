using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;
using UnityEngine.UI;

public class StoryView : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Transform container;

    [SerializeField]
    private ConversationBubble playerConversationBubblePrefab;

    [SerializeField]
    private ConversationBubble npcConversationBubblePrefab;

    [SerializeField]
    private OptionsPanel optionsPanel;

    [SerializeField]
    private ScrollRect scrollView;

    private StoryPresenter presenter;

    public void InjectPresenter(StoryPresenter storyPresenter)
    {
        presenter = storyPresenter;
        optionsPanel.InjectPresenter(presenter);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            presenter.ContinueStory();
        }
    }

    public void CreateTextBubble(string text, bool belongsToPlayer)
    {
        ConversationBubble bubble;

        if (belongsToPlayer)
        {
            bubble = Instantiate(playerConversationBubblePrefab, container);
        }
        else
        {
            bubble = Instantiate(npcConversationBubblePrefab, container);
        }

        bubble.SetText(text);
        bubble.gameObject.SetActive(true);

        scrollView.ScrollToBottom();

    }

    public void DisplayOptions(List<Choice> choices)
    {
        optionsPanel.Show(choices);
    }

    public void HideOptions()
    {
        optionsPanel.Hide();
    }
}
