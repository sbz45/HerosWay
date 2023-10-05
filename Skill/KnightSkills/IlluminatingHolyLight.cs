using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "IlluminatingHolyLight", menuName = "Skill/Knight/IlluminatingHolyLight", order = 0)]
 public class IlluminatingHolyLight : Skill
{
    protected override void SkillBody(Character character)
    {
        skillAttackInstance.attacked = character;
        skillAttackInstance.damageSpiritual = character.SansChange
        (
            (int)(15 + character.DEFENCE * 1.5)
        );
        
    }
}
