using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OptionButton : MonoBehaviour
{
    [SerializeField]
    private Button _button;

    [SerializeField]
    private TextMeshProUGUI _text;

    private Choice _choice;


    public void SetupOption(Choice choice, StoryPresenter storyPresenter)
    {
        _choice = choice;
        _text.SetText(choice.text);
        _button.onClick.AddListener(() =>
        {
            storyPresenter.ReceiveChoise(_choice);
        });
    }
}
