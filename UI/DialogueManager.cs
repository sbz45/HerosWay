using cherrydev;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager instance;
    public DialogBehaviour DialogBehaviour;
    void Awake()
    {
        instance = this;
    }

    public void ShowDialogue(DialogNodeGraph dialogNodeGraph)
    {
        DialogBehaviour.StartDialog(dialogNodeGraph);
    }
    /// <summary>
    /// 当需要在对话结束时打开面板时使用这个方法
    /// </summary>
    /// <param name="action"></param>
    public void AddListenerToOnDialogFinished(UnityAction action)
    {
        DialogBehaviour.AddListenerToOnDialogFinished(action);
        DialogBehaviour.AddListenerToOnDialogFinished(()=>DialogBehaviour.RemoveListenerToOnDialogFinished(action));
    }
    private void RemoveListenerToOnDialogFinished(UnityAction action)
    {
        DialogBehaviour.RemoveListenerToOnDialogFinished(action);
    }
}
