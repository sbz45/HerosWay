using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weakened", menuName = "Buff/Weakened", order = 0)]
public class Weakened : Buff
{
    Weakened()
    {
        isAttacking = true;
        buffName = "Weaken";
        buffDescription = "使角色的攻击在释放攻击和技能时减少最大攻击力*50%";
    }

    public override void DeEffect(Character character)
    {

        owner.attack += (int)(owner.ATTACK * 0.5);
    }
    /// <summary>
    /// 使角色的攻击在释放攻击和技能时减少50%
    /// </summary>
    /// <param name="character"></param>
    public override void TakeEffect(Character character)
    {
        owner.attack -= (int ) (owner.ATTACK*0.5);
    }


}
