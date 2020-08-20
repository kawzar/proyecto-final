using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessagingService : IMessagingService
{
    private IStoryPresenter storyPresenter;
    private IMessageListPresenter messageListPresenter;

    public MessagingService(IStoryPresenter storyPresenter, IMessageListPresenter messageListPresenter)
    {
        this.storyPresenter = storyPresenter;
        this.messageListPresenter = messageListPresenter;

        this.storyPresenter.Closed += OnStoryPresenterClosed;
    }

    private void OnStoryPresenterClosed()
    {
        messageListPresenter.DisplayView(true);
    }
}
