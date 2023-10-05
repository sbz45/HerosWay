using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SpiritOfKingdom", menuName = "Skill/Knight/SpiritOfKingdom", order = 0)]
 public class SpiritOfKingdom : Skill
{
    /*public Buff buffHolyLight;*/
    protected override void SkillBody(Character target)
    {
        skillAttackInstance.attacked = target;
        owner.DEFENCE++;
        owner.defence++;
        skillAttackInstance.damagePhysical= owner.attack + owner.DEFENCE;
        
    }
}
