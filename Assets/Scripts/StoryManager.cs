using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Ink.Runtime;
using UnityEngine;

public class StoryManager : MonoBehaviour
{
    public static StoryManager Instance;

    [SerializeField]
    private StoryPresentationMono _presentation;

    [SerializeField]
    private TextAsset _inkTextAsset;
    private Story _story;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        _story = new Story(_inkTextAsset.text);
    }

    public void ContinueStory()
    {
        if (!_story.canContinue) return;

        string storyText = _story.Continue();
        _presentation.CreateTextBubble(storyText, false);


        if (_story.currentChoices.Any())
        {
            _presentation.DisplayOptions(_story.currentChoices);
        }
        else
        {
            ContinueStory();
        }
    }

    public void OnClickChoiceButton(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        _presentation.HideOptions();
        _presentation.CreateTextBubble(choice.text, true);
        ContinueStory();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
        }
    }
}
