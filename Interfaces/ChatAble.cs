using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using cherrydev;
using UnityEngine.Events;

public class ChatAble : Interractable
{
    [SerializeField] DialogNodeGraph dialogueGraph;
    [SerializeField] UnityEvent<Character> methodCalledEndOfDialogue;
    private bool isChatable=true;
    public override void Respond(Character character)
    {
        if (!isChatable) return;
        DialogueManager.instance.ShowDialogue(dialogueGraph.ReplaceAllDefaultName(character.name));
        isChatable = false;
        if (methodCalledEndOfDialogue != null)
        {
            DialogueManager.instance.AddListenerToOnDialogFinished(()=>methodCalledEndOfDialogue.Invoke(character));
            DialogueManager.instance.AddListenerToOnDialogFinished(() =>this.isChatable=true);
        }
        
    }

}
