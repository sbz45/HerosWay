using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "RoundSurface", menuName = "Buff/RoundSurface", order = 0)]
public class RoundSurface : Buff
{
    RoundSurface()
    {
        isAttacked = true;
        buffName = "RoundSurface";
        buffDescription = "每次受到攻击前，获得50%的物理抗性提升";
    }
    public override void DeEffect(Character character)
    {
        owner.physicalAttackResistance -= owner.PHYSICALATTACKRESISTANCE * (float)0.5;
    }

    public override void TakeEffect(Character character)
    {
        owner.physicalAttackResistance += owner.PHYSICALATTACKRESISTANCE * (float)0.5;
    }


}
