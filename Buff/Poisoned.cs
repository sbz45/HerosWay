using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Poisoned", menuName = "Buff/Poisoned", order = 0)]
public class Poisoned : Buff
{
    Poisoned()
    {
        isRoundEnd = true;
        buffName = "Poisoned";
        buffDescription = "每个回合结束时，减少5%最大生命值的生命值";
    }
    public override void DeEffect(Character character)
    {
        
    }

    public override void TakeEffect(Character character)
    {
        owner.HealthChange(-(int)(owner.HEALTH * 0.1));
    }


}
