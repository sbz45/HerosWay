using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Scratch", menuName = "Skill/Enemy/TheDrowned/Scratch", order = 0)]

 public class Scratch : Skill
{
    [SerializeField]Buff bleeding;
    
    Scratch()
    {
        skillName = "抓挠";
        skillDescription = "附加流血，造成伤害";
        dicePointCost = 5;

    }
    protected override void SkillBody(Character target)
    {
        skillAttackInstance.attacked = target;
        skillAttackInstance.buffsAttached.Add(bleeding);
        skillAttackInstance.damagePhysical = owner.attack;
    }


}
