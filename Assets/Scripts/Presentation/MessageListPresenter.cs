using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MessageListPresenter : IMessageListPresenter
{
    private List<MessagePreviewModel> messages;
    private MessageListView view;

    public IEnumerable<MessagePreviewModel> MessagePreviewModels => messages.OrderByDescending(m => m.Date);

    public MessageListPresenter(MessageListView listview)
    {
        this.view = listview;
    }

    public void DisplayView(bool display)
    {
        view.gameObject.SetActive(display);
    }
}
