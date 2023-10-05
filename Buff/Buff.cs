using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Buff:ScriptableObject
{
    protected Character owner;

    public int index;
    public bool isState;
    public bool isAttacked;
    public bool isAttacking;
    public bool isRoundEnd;
    public bool isRoundStart;

    public string buffName;
    public string buffDescription;
    public Sprite buffIcon;
    ///-1 represents eternal,default 1
    public int duration=1;
    public BuffType type=BuffType.negative;
    
    ///level for stack
    public int level=1;
    public bool isStackable;

    public void RegisterOwner(Character character)
    {
        owner = character;
    }
    public  Buff   GetCopy()
    {
        Buff newBuff = (Buff)ScriptableObject.CreateInstance(this.GetType());
        newBuff.index=index;
        newBuff.isState=isState;
        newBuff.isAttacked=isAttacked;
        newBuff.isAttacking=isAttacking;
        newBuff.isRoundEnd=isRoundEnd;

        newBuff.buffName=buffName;
        newBuff.buffDescription=buffDescription;
        newBuff.buffIcon=buffIcon;
        return newBuff;
    }
    public abstract void TakeEffect(Character character);
    /*{
        for (int i = 0; i < level; i++)
        {
            character.attack -= 10;
            var type = character.characterType;            if (type == CharacterType.enemy)
            {

            }
            else
            {

            }
        }

    }*/
    public abstract void DeEffect(Character character);

}
public enum BuffType
{
    positive,
    negative,
    neutral
}
