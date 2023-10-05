using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SwordBackHit", menuName = "Skill/Knight/SwordBackHit", order = 0)]
 public class SwordBackHit : Skill
{
    protected override void SkillBody(Character character)
    {
        character.SansChange(-20);
        character.opponent.TakeAttack((int)(1.75 * character.ATTACK));
    }
}
