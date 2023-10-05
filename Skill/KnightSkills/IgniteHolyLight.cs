using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
[CreateAssetMenu(fileName = "IgniteHolyLight", menuName = "Skill/Knight/IgniteHolyLight", order = 0)]
 public class IgniteHolyLight : Skill
{
    [SerializeField] int holyLightIndex = 0;
    protected override void SkillBody(Character target)
    {
        this.owner.SansChange(-25);
        skillAttackInstance.attacked = target;
        skillAttackInstance.damagePhysical = (int)((owner.ATTACK + owner.DEFENCE) * 0.5);
        skillAttackInstance.damageSpiritual = (int)((owner.ATTACK + owner.DEFENCE) * 0.5);
        foreach (Buff b in target.buffs)
        {
            if (b.index== holyLightIndex)
            {

                target.buffs.Remove(b);
                skillAttackInstance.damagePhysical += 5 * b.level;
                skillAttackInstance.damageSpiritual += 5 * b.level;
            }
        }
    }
}
