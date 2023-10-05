using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HolyLight", menuName = "Buff/HolyLight", order = 0)]
public class HolyLight : Buff
{
    HolyLight()
    {
        isRoundEnd = true;
        buffName = "HolyLight";
        buffDescription = "每个回合结束时，回复一点精神值（可叠加）";
    }
    public override void DeEffect(Character character)
    {
        throw new System.NotImplementedException();
    }

    public override void TakeEffect(Character character)
    {
        character.sans += level;
    }

        
}
