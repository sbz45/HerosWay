using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Slowed", menuName = "Buff/Slowed", order = 0)]
public class Slowed : Buff
{
    Slowed()
    {
        isState = true;
        buffName = "Slowed";
        buffDescription = "骰子所得点数减二";
    }
    public override void DeEffect(Character character)
    {
        throw new System.NotImplementedException();
    }

    public override void TakeEffect(Character character)
    {
        FightEventListener.OnDiceTrown += EventListener;
    }
    public void EventListener(Dice dice,Character character) 
    {
        if (character == owner) dice.currentPoint -= 2;
            }

}
