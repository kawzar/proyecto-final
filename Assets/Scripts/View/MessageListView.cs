using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessageListView : MonoBehaviour
{
    [SerializeField]
    private Canvas canvas;

    [SerializeField]
    private Transform container;

    [SerializeField]
    private MessagePreview messagePreviewPrefab;

    [SerializeField]
    private ScrollRect scrollView;

    private IMessageListPresenter presenter;

    public void InjectPresenter(IMessageListPresenter listPresenter)
    {
        presenter = listPresenter;
    }

}
