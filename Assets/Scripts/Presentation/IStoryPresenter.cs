using System;
using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public interface IStoryPresenter
{
    event Action Closed;
    void ReceiveChoice(Choice choice);
    void ContinueStory();
    void ReceiveCloseAction();
}
