using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="SteelWill",menuName = "Skill/Knight/SteelWill", order =0)]
 public class SteelWill : Skill
{
    [SerializeField] Buff buffHolyLight;
    protected override void SkillBody(Character target)
    {
        /*character.GetBuff();*/
        owner.HealthChange((int)((owner.HEALTH - owner.health)*0.25)+15);
        owner.DefenceChange((int)((owner.DEFENCE) * 0.5));
        owner.SansChange((int)(20));
        owner.GetBuff(buffHolyLight);
    }
}
