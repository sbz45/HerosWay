using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "WeakeningAttack", menuName = "Skill/Knight/WeakeningAttack", order = 0)]

 public class WeakeningAttack : Skill
{
    public Buff buffWeaken;
    protected override void SkillBody(Character target)
    {
        owner.SansChange(-20);
        
        
        skillAttackInstance.attacked = target;
        skillAttackInstance.damagePhysical = (int)((owner.ATTACK) * 1.2);
        skillAttackInstance.buffsAttached.Add(buffWeaken);
    }
}
