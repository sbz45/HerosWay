using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "HolyLight", menuName = "Buff/HolyLight", order = 0)]
public class HolyLight : Buff
{
    HolyLight()
    {
        isRoundEnd = true;
        buffName = "HolyLight";
        buffDescription = "ÿ���غϽ���ʱ���ظ�һ�㾫��ֵ���ɵ��ӣ�";
    }
    public override void DeEffect(Character character)
    {
        throw new System.NotImplementedException();
    }

    public override void TakeEffect(Character character)
    {
        character.sans += level;
    }

        
}
