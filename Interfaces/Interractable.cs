using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public  class Interractable :MonoBehaviour
{
    public UnityEvent<Character> UnityEventOnInteract;
    public UnityEvent UnityEventWithoutArgumentOnInteract;
    public virtual void Respond(Character character)
    {

        UnityEventOnInteract.Invoke(character);
        UnityEventWithoutArgumentOnInteract.Invoke();
    }
    public void Test()
    {
        Debug.Log(this.ToString());
    }
}
