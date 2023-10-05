using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "DragIntoMire", menuName = "Skill/Enemy/TheDrowned/DragIntoMire", order = 0)]
 public class DragIntoMire : Skill
{
    [SerializeField] Buff buffPoisoned;
    [SerializeField] Buff buffSlowed;
    DragIntoMire()
    {
        skillName = "��������";
        skillDescription = "����ճ�͡��ж�";
        dicePointCost =4;

    }
    protected override void SkillBody(Character target)
    {
        skillAttackInstance.attacked = target;
        skillAttackInstance.buffsAttached.Add(buffPoisoned);
        skillAttackInstance.buffsAttached.Add(buffSlowed);
    }


}
