using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DoublePressure", menuName = "Skill/Knight/DoublePressure", order = 0)]
public class DoublePressure : Skill
{
    
    protected override void SkillBody(Character character)
    {
        skillAttackInstance.attacked = character;
        skillAttackInstance.damagePhysical = (int)((character.opponent.HEALTH - character.opponent.health) * 0.2) + character.DEFENCE;
        skillAttackInstance.damageSpiritual = (int)((character.opponent.SANS - character.opponent.sans) * 0.3) + character.attack;
        
    }
}
