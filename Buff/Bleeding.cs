using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Bleeding", menuName = "Buff/Bleeding", order = 0)]
public class Bleeding : Buff
{
    Bleeding()
    {
        isRoundEnd = true;
        buffName = "Bleeding";
        buffDescription = "��ʧ����ֵ������ʧ����ֵԽ�ߣ������˺�Խ�ߣ����Ϊ10%�������ֵ��";
    }
    public override void DeEffect(Character character)
    {
       
    }

    public override void TakeEffect(Character character)
    {
        owner.health -= (int)((owner.HEALTH - owner.health) * 0.1);
    }


}
