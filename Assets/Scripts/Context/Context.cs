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

    private void Awake()
    {
        storyView.InjectPresenter(new StoryPresenter(storyView, new Story(storyTextAsset.text)));
    }
}
