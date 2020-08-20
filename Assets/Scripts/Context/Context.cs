using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class Context : MonoBehaviour
{
    [SerializeField]
    private TextAsset storyTextAsset;

    [SerializeField]
    private StoryView storyView;

    [SerializeField]
    private MessageListView messageListView;

    private IMessagingService messagingService;

    private void Awake()
    {
        IStoryPresenter storyPresenter = new StoryPresenter(storyView, new Story(storyTextAsset.text));
        IMessageListPresenter messageListPresenter = new MessageListPresenter(messageListView);
        storyView.InjectPresenter(storyPresenter);
        messageListView.InjectPresenter(messageListPresenter);
        messagingService = new MessagingService(storyPresenter, messageListPresenter);
    }
}
