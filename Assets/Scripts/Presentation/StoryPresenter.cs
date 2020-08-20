using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using UnityEngine;

public class StoryPresenter : IStoryPresenter
{
    private Story story;
    private StoryView view;

    public StoryPresenter(StoryView storyView, Story story)
    {
        this.story = story;
        this.view = storyView;
    }

    public event Action Closed;

    public void ContinueStory()
    {
        if (!story.canContinue) return;

        string storyText = story.Continue();
        view.CreateTextBubble(storyText, false);


        if (story.currentChoices.Any())
        {
            view.DisplayOptions(story.currentChoices);
        }
        else
        {
            ContinueStory();
        }
    }

    public void ReceiveChoice(Choice choice)
    {
        story.ChooseChoiceIndex(choice.index);
        view.HideOptions();
        view.CreateTextBubble(choice.text, true);
        ContinueStory();
    }

    public void ReceiveCloseAction()
    {
        Closed?.Invoke();
    }
}
