using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "MucusSurface", menuName = "Skill/Enemy/TheDrowned/MucusSurface", order = 0)]
 public class MucusSurface : Skill
{
    [SerializeField] Buff buffRoundSurface;

    MucusSurface()
    {
        skillName = "ճҺ��Ƥ";
        skillDescription = "���Բ��";
        dicePointCost = 5;

    }
    protected override void SkillBody(Character target)
    {
        skillAttackInstance.attacked = target;
        owner.GetBuff(buffRoundSurface);
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
