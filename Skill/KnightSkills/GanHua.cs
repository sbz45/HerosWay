using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "GanHua", menuName = "Skill/Knight/GanHua", order = 0)]
 public class GanHua : Skill
{
    protected override void SkillBody(Character target)
    {
        skillAttackInstance.attacked = target;
        skillAttackInstance.damageSpiritual = target.HealthChange(target.HEALTH - target.health);
    }
}
