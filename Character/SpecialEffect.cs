using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SpecialEffect
{
    //SpecialEffect is attached to the Attack (in a list<SpecialEffect>,which belongs to Character),unleashes once the attack is taken by the enemy
    public int index;
    public string specialEffectName;
    public string specialEffectDescription;
    //Affects on the enemy to be attacked
    public abstract void TakeEffect(Character character);

    public abstract void DeEffect(Character character);
 

}
