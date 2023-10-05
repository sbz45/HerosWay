using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bleeding", menuName = "Buff/Bleeding", order = 0)]
public class Bleeding : Buff
{
    Bleeding()
    {
        isRoundEnd = true;
        buffName = "Bleeding";
        buffDescription = "损失生命值，已损失生命值越高，所受伤害越高（最高为10%最大生命值）";
    }
    public override void DeEffect(Character character)
    {
       
    }

    public override void TakeEffect(Character character)
    {
        owner.health -= (int)((owner.HEALTH - owner.health) * 0.1);
    }


}
