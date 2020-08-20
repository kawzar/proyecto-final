using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using Ink.Runtime;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class OptionsPanel : MonoBehaviour
{
    [SerializeField]
    private CanvasGroup canvas;

    [SerializeField]
    private Transform container;

    [SerializeField]
    private OptionButton optionPrefab;

    [SerializeField]
    private float fadeTime = 0.25f;

    private IStoryPresenter storyPresenter;

    // TODO: review if this is a valid option to inject presenter
    public void InjectPresenter(IStoryPresenter storyPresenter)
    {
        this.storyPresenter = storyPresenter;
    }

    public void Show(List<Choice> choices)
    {
        container.gameObject.Clear();

        foreach (var choice in choices)
        {
            var option = Instantiate(optionPrefab, container);
            option.SetupOption(choice, storyPresenter);
            option.gameObject.SetActive(true);
        }

        gameObject.SetActive(true);
        canvas.DOFade(1, fadeTime);
    }

    public void Hide()
    {
        canvas.DOFade(0, fadeTime);
        gameObject.SetActive(false);
    }
}
