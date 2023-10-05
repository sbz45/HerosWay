using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "TiredOfFight", menuName = "Skill/Knight/TiredOfFight", order = 0)]
 public class TiredOfFight : Skill
{
    protected override void SkillBody(Character character)
    {
        character.HealthChange(
            character.SansChange(-character.sans + 1)
        );
    }
}
