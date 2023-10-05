using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.TextCore.Text;

public class FightEventListener : MonoBehaviour
{
    /// <summary>
    /// ��isAttackedBuff��Ч�󣬿�ʼ��Attack���д���ǰ�������¼���isAttackedBuff��Ч��һֱ����������������ֵ�ı仯���
    /// </summary>
    public static event Action<Attack> OnCharacterTakingAttack;
    /// <summary>
    /// ��������������ֵ�仯֮�����̴���
    /// </summary>
    public static event Action<int, Character> OnCharacterTakingPhysicalDamage;
    /// <summary>
    /// ��������������ֵ�仯֮�����̴���
    /// </summary>
    public static event Action<int, Character> OnCharacterTakingSpiritualDamage;
    /// <summary>
    /// �ڹ������������͵�����������ǰһ�̴�����ע�⣬attackingBuff�ڴ�ʱ��Ȼ��Ч�����ڱ�������������ɹ�����ʧЧ
    /// </summary>
    public static event Action<Attack> OnCharacterDeliveringAttack;
    /// <summary>
    /// ÿ������ͷż���ʱ�����˼��������ɵĹ�����Ŀ�겻Ϊ�գ���ᴥ�����¼����ڽ���������֮ǰ
    /// </summary>
    public static event Action<Skill, Attack> OnCharacterDeliveringSkillAttack;
    /// <summary>
    /// ÿ������ͷż���ʱ�����˼��������ɵĹ�����Ŀ�겻Ϊ�գ���ᴥ�����¼����ڽ���������֮ǰ
    /// </summary>
    public static event Action<Dice, Character> OnDiceTrown;
    public static event Action<Character, Character> OnFightStart;
    public static event Action<Character, Character> OnFightEnd;


    public static void ResetAllEvent()
    {
        OnCharacterTakingAttack = null;
        OnCharacterTakingPhysicalDamage = null;
        OnCharacterTakingSpiritualDamage = null;
        OnCharacterDeliveringAttack = null;
        OnFightStart = null;
        OnFightEnd = null;
        OnDiceTrown = null;
    }
    #region public invoke method
    public static void DiceTrown(Dice dice, Character character)
    {
        Debug.Log("DiceTrown" + dice.currentPoint.ToString());
        if (OnDiceTrown != null)
            OnDiceTrown.Invoke(dice, character);
        /*//yield return WaitForCoroutines(OnCharacterTakingAttack.GetInvocationList());*/
    }
    public static void CharacterTakingAttack(Attack attack, Character character)
    {
        Debug.Log("OnCharacterTakingAttack");
        if (OnCharacterTakingAttack != null)
            OnCharacterTakingAttack.Invoke(attack);
        //yield return WaitForCoroutines(OnCharacterTakingAttack.GetInvocationList());
    }
    /// <summary>
    /// ������Ѫ���仯����0ʱ����
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="character"></param>
    public static void CharacterTakingPhysicalDamage(int attack, Character character)
    {

        if (OnCharacterTakingPhysicalDamage != null)
        {
            Debug.Log("OnCharacterTakingPhysicalDamage" + attack.ToString());
            OnCharacterTakingPhysicalDamage.Invoke(attack, character);
        }

        //yield return WaitForCoroutines(OnCharacterTakingPhysicalDamage.GetInvocationList());
    }
    /// <summary>
    /// �����ھ���仯����0ʱ����
    /// </summary>
    public static void CharacterTakingSpiritualDamage(int attack, Character character)
    {

        if (OnCharacterTakingSpiritualDamage != null)
        {
            Debug.Log("OnCharacterTakingSpiritualDamage" + attack.ToString());
            OnCharacterTakingSpiritualDamage.Invoke(attack, character);
        }

        //yield return WaitForCoroutines(OnCharacterTakingSpiritualDamage.GetInvocationList());
    }
    /// <summary>
    /// �ڹ������������͵�����������ǰһ�̴�����ע�⣬attackingBuff�ڴ�ʱ��Ȼ��Ч�����ڱ�������������ɹ�����ʧЧ
    /// </summary>
    public static void CharacterDeliveringSkillAttack(Skill skill, Attack attack)
    {
        Debug.Log("OnCharacterDeliveringSkillAttack");
        if (OnCharacterDeliveringSkillAttack != null)
            OnCharacterDeliveringSkillAttack.Invoke(skill, attack);
        //yield return WaitForCoroutines(OnCharacterDeliveringSkillAttack.GetInvocationList());
    }
    /// <summary>
    /// after thr 
    /// </summary>
    /// <param name="attack"></param>
    /// <param name="character"></param>
    public static void CharacterDeliveringAttack(Attack attack, Character character)
    {
        Debug.Log("OnCharacterDeliveringAttack");
        if (OnCharacterDeliveringAttack != null)
            OnCharacterDeliveringAttack.Invoke(attack);
        //yield return WaitForCoroutines(OnCharacterDeliveringAttack.GetInvocationList());
    }
    public static void FightStart(Character character1, Character character2)
    {
        Debug.Log("OnFightStart");
        if (OnFightStart != null)
            OnFightStart.Invoke(character1, character2);
        //yield return WaitForCoroutines(OnFightStart.GetInvocationList());
    }
    public static void FightEnd(Character characterLose, Character characterWin)
    {
        Debug.Log("OnFightEnd");
        if (OnFightEnd != null)
            OnFightEnd.Invoke(characterLose, characterWin);
        //yield return WaitForCoroutines(OnFightEnd.GetInvocationList());
    }
    #endregion
    #region public addListenerOnceMethod
    public void AddListenerToOnCharacterTakingAttackOnce(Action<Attack> action)
    {
        OnCharacterTakingAttack += action;
        OnCharacterTakingAttack += ((Attack) => OnCharacterTakingAttack -= action);
    }
    public void AddListenerToOnCharacterTakingPhysicalDamageOnce(Action<int,Character> action)
    {
        OnCharacterTakingPhysicalDamage += action;
        OnCharacterTakingPhysicalDamage += ((Attack,fgh) => OnCharacterTakingPhysicalDamage -= action);
    }
    public void AddListenerToOnCharacterTakingSpiritualDamageOnce(Action<int, Character> action)
    {
        OnCharacterTakingSpiritualDamage += action;
        OnCharacterTakingSpiritualDamage += ((Attack,asd) => OnCharacterTakingSpiritualDamage -= action);
    }
    public void AddListenerToOnCharacterDeliveringAttackOnce(Action<Attack> action)
    {
        OnCharacterDeliveringAttack += action;
        OnCharacterDeliveringAttack += ((Attack) => OnCharacterDeliveringAttack -= action);
    }
    public void AddListenerToOnCharacterDeliveringSkillAttackOnce(Action<Skill, Attack> action)
    {
        OnCharacterDeliveringSkillAttack += action;
        OnCharacterDeliveringSkillAttack += ((Skill ,Attack) => OnCharacterDeliveringSkillAttack -= action);
    }
    public void AddListenerToOnDiceTrownOnce(Action<Dice,Character> action)
    {
        OnDiceTrown += action;
        OnDiceTrown += ((Attack,c) => OnDiceTrown -= action);
    }
    public void AddListenerToOnFightStartOnce(Action<Character,Character> action)
    {
        OnFightStart += action;
        OnFightStart += ((c,c2) => OnFightStart -= action);
    }
    public void AddListenerToOnFightEndOnce(Action<Character, Character> action)
    {
        OnFightEnd += action;
        OnFightEnd += ((c, c2) => OnFightEnd -= action);
    }
    #endregion
}

