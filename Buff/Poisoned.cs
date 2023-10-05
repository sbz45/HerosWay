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
        buffDescription = "ÿ���غϽ���ʱ������5%�������ֵ������ֵ";
    }
    public override void DeEffect(Character character)
    {
        
    }

    public override void TakeEffect(Character character)
    {
        owner.HealthChange(-(int)(owner.HEALTH * 0.1));
    }


}
