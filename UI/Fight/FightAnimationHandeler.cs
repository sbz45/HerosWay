using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FightAnimationHandeler : MonoBehaviour
{
    public bool isAnimationPlaying;
    public static FightAnimationHandeler instance;
    public FightPanelcontroller FightPanelcontroller;

    public DamageLable damageLablePlayer;
    public DamageLable damageLableEnemy;
    public TextField FightText;
    public GameObject testBut;

    WaitForSeconds waitFor1 = new WaitForSeconds(1);
    internal void ShowAttackName(Attack attack)
    {
        FightText.SetText(attack.attackName);
        FightText.SlideIn();
        testBut.transform.DOMoveX(1, 1);
    }

    internal void DisableAttackName()
    {
        FightText.PopOut();
    }
    private void Awake()
    {
        instance = this;
        /* FightEventListener.OnCharacterDeliveringAttack += AttackAnimation;*/
        /* FightEventListener.OnCharacterTakingPhysicalDamage += TakingPhysicalAttackAnimation;
         FightEventListener.OnCharacterTakingSpiritualDamage += TakingSpiritualAttackAnimation;*/
        FightEventListener.OnCharacterTakingPhysicalDamage += (damage, character) => StartCoroutine(TakingPhysicalAttackAnimation(damage, character) );
        FightEventListener.OnCharacterTakingSpiritualDamage += (damage, character) => StartCoroutine(TakingSpiritualAttackAnimation(damage, character)) ;
        
    }
    private bool atkAnimationPlaying= true;
    public IEnumerator AttackAnimation(Attack attack)
    {
        atkAnimationPlaying = true;
        FightAnimationHandeler.instance.ShowAttackName(attack);
        if (attack.attacker.characterType != CharacterType.enemy)
        {
            Debug.Log("AttackAnimationPlayerStart");
            yield return FightPanelcontroller.playerImage.transform.DOPunchPosition(new Vector2(50, 0), 1, 1, (float)0.1, false).SetEase(Ease.Flash).WaitForCompletion();
            yield return waitFor1;
            atkAnimationPlaying = false;
            yield return FightPanelcontroller.enemyImage.transform.DOPunchPosition(new Vector2(70, 0), 1, 5, (float)0.1, false).WaitForCompletion();
        }
        else
        {
            Debug.Log("AttackAnimationEnemyStart");
            yield return FightPanelcontroller.enemyImage.transform.DOPunchPosition(new Vector2(-50, 0), 1, 1, (float)0.1, false).SetEase(Ease.Flash).WaitForCompletion();
            yield return waitFor1;
            atkAnimationPlaying = false;
            yield return FightPanelcontroller.playerImage.transform.DOPunchPosition(new Vector2(-70, 0), 1, 5, (float)0.1, false).WaitForCompletion();

        }

        FightAnimationHandeler.instance.DisableAttackName();
        Debug.Log("AttackAnimationEnd");
        
    }
    WaitUntil WaitUntilAttackedAnimaiton;
    /// <summary>
    /// starts if Attack animation is not playing
    /// </summary>
    /// <param name="damage"></param>
    /// <param name="character"></param>
    public IEnumerator TakingPhysicalAttackAnimation(int damage, Character character)
    {
        if (WaitUntilAttackedAnimaiton == null) WaitUntilAttackedAnimaiton = new WaitUntil(() => !atkAnimationPlaying);
        yield return WaitUntilAttackedAnimaiton;
        if (character.characterType == CharacterType.enemy)
        {
            StartCoroutine( damageLableEnemy.Show(damage,DamageType.physical));
        }
        else
        {
            StartCoroutine(damageLablePlayer.Show(damage, DamageType.physical));
        }
        
    }
    public IEnumerator TakingSpiritualAttackAnimation(int damage, Character character)
    {
        if (WaitUntilAttackedAnimaiton == null) WaitUntilAttackedAnimaiton = new WaitUntil(() => !atkAnimationPlaying);
        yield return WaitUntilAttackedAnimaiton;
        if (character.characterType == CharacterType.enemy)
        {
            StartCoroutine(damageLableEnemy.Show(damage, DamageType.spiritual));
        }
        else
        {
            StartCoroutine(damageLablePlayer.Show(damage, DamageType.spiritual));
        }
        
    }

    /// <summary>
    /// waits for attacked animation
    /// </summary>
    /// <returns></returns>
/*    public IEnumerator BuffAnimation()
    {

    }*/
}

