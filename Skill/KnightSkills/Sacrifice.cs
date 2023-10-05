using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Sacrifice", menuName = "Skill/Knight/Sacrifice", order = 0)]
 public class Sacrifice : Skill
{
    
    protected override void SkillBody(Character target)
    {
        skillAttackInstance.attacked = target;
        int damage = owner.sans / 2;
        owner.SansChange(-damage);
        skillAttackInstance.damageSpiritual = (damage);
        
    }
}
