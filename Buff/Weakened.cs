using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Weakened", menuName = "Buff/Weakened", order = 0)]
public class Weakened : Buff
{
    Weakened()
    {
        isAttacking = true;
        buffName = "Weaken";
        buffDescription = "ʹ��ɫ�Ĺ������ͷŹ����ͼ���ʱ������󹥻���*50%";
    }

    public override void DeEffect(Character character)
    {

        owner.attack += (int)(owner.ATTACK * 0.5);
    }
    /// <summary>
    /// ʹ��ɫ�Ĺ������ͷŹ����ͼ���ʱ����50%
    /// </summary>
    /// <param name="character"></param>
    public override void TakeEffect(Character character)
    {
        owner.attack -= (int ) (owner.ATTACK*0.5);
    }


}
