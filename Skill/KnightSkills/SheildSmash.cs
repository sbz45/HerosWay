using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SheildSmash", menuName = "Skill/Knight/SheildSmash", order = 0)]
 public class SheildSmash : Skill
{
    public Buff buffStun;
    protected override void SkillBody(Character character)
    {
        skillAttackInstance.attacked = character;
        skillAttackInstance.buffsAttached.Add(buffStun);
        skillAttackInstance.damagePhysical = (int)(character.DEFENCE * 1.5);

        character.SansChange(-15);
    }
}
