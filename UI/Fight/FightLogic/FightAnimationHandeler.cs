using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Pool;

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

    List<Animation> animationsToPlay = new List<Animation>();
    ObjectPool<Animation> objectPool = new UnityEngine.Pool.ObjectPool<Animation>(() => new Animation());
    public void AddAnimation(AnimationType animationType, Character character,string value, bool ifWaitUntilEnd)
    {
        Animation animation = objectPool.Get();
        animation.SetProperty(animationType,character, value, ifWaitUntilEnd);
        animationsToPlay.Add(animation);
        
    }
    public void AddAnimation(AnimationType animationType, Character character,float value, bool ifWaitUntilEnd)
    {
        Animation animation = objectPool.Get();
        animation.SetProperty(animationType, character,value, ifWaitUntilEnd);
        animationsToPlay.Add(animation);

    }
    public void PlayAnimations()
    {
        event OnAnimationsEnd;
        foreach(var i in animationsToPlay)
        {
            
            if(i.WaitForCompletion)
            {
            switch (i.animationType)
            {
                case AnimationType.Attack:
                    ;
                     yield return StartCoroutine(AttackAnimation());
                     break;
                case AnimationType.Attacked:
                    ;
                     yield return StartCoroutine(AttackedAnimation());;
                     break;
                case AnimationType.TakeDamage:
                    ; 
                    yield return StartCoroutine(AttackAnimation());;
                    break;

            }
            }else
            {

            switch (i.animationType)
            {
                case AnimationType.Attack:
                    ;
                     StartCoroutine(AttackAnimation());
                     break;
                case AnimationType.Attacked:
                    ;
                     StartCoroutine(AttackedAnimation());;
                     break;
                case AnimationType.TakeDamage:
                    ; 
                    StartCoroutine(AttackAnimation());;
                    break;

            }
            }
            
                
        }
        OnAnimationsEnd?.Invoke();
        OnAnimationsEnd=null;
        animationsToPlay.Clear();
    }
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
    public IEnumerator AttackAnimation( Character character,string attackName)
    {
        atkAnimationPlaying = true;
        FightAnimationHandeler.instance.ShowAttackName(attack);
        if (attack.attacker.characterType != CharacterType.enemy)
        {
            Debug.Log("AttackAnimationPlayerStart");
            yield return FightPanelcontroller.playerImage.transform.DOPunchPosition(new Vector2(50, 0), 1, 1, (float)0.1, false).SetEase(Ease.Flash).WaitForCompletion();
            yield return waitFor1;
            atkAnimationPlaying = false;
            
        }
        else
        {
            Debug.Log("AttackAnimationEnemyStart");
            yield return FightPanelcontroller.enemyImage.transform.DOPunchPosition(new Vector2(-50, 0), 1, 1, (float)0.1, false).SetEase(Ease.Flash).WaitForCompletion();
            yield return waitFor1;
            atkAnimationPlaying = false;
            

        }

        
        Debug.Log("AttackAnimationEnd");
        
    }
    public IEnumerator AttackedAnimation(Character character)
    {
       
        
        if (character.characterType != CharacterType.enemy)
        {
            Debug.Log("AttackedAnimationPlayerStart");
           
            yield return FightPanelcontroller.enemyImage.transform.DOPunchPosition(new Vector2(70, 10), 1, 5, (float)0.1, false).WaitForCompletion();
        }
        else
        {
            Debug.Log("AttackedAnimationEnemyStart");

            yield return FightPanelcontroller.playerImage.transform.DOPunchPosition(new Vector2(-70, -10), 1, 5, (float)0.1, false).WaitForCompletion();

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
    public IEnumerator TakingPhysicalDamagenimation(int damage, Character character)
    {
        
        if (character.characterType == CharacterType.enemy)
        {
            StartCoroutine( damageLableEnemy.Show(damage,DamageType.physical));
        }
        else
        {
            StartCoroutine(damageLablePlayer.Show(damage, DamageType.physical));
        }
        
    }
    public IEnumerator TakingSpiritualDamageAnimation(int damage, Character character)
    {
        
       
        if (character.characterType == CharacterType.enemy)
        {
            StartCoroutine(damageLableEnemy.Show(damage, DamageType.spiritual));
        }
        else
        {
            StartCoroutine(damageLablePlayer.Show(damage, DamageType.spiritual));
        }

    }


}
/// <summary>
/// Attack Animation Needs string value
/// Attacked needs no value
/// takedamage needs float
/// takeeffect need svalue,fvalue
/// </summary>
public class Animation 
{
    public Character character;
    public AnimationType animationType { get; private set; }
    public string svalue { get; private set; }
    public float fvalue { get; private set; }
    public bool isWaitUntilEnd { get; private set; }
    public Animation(AnimationType animationType,Character character,string value,bool ifWaitUntilEnd)
    {
        this.animationType = animationType;
        this.svalue = value;
        this.isWaitUntilEnd = ifWaitUntilEnd;
        this.character=character;
    }
    public Animation()
    {

    }
    public void SetProperty(AnimationType animationType,Character character, string value, bool ifWaitUntilEnd)
    {
        this.character=character;
        this.animationType = animationType;
        this.svalue = value;
        this.isWaitUntilEnd = ifWaitUntilEnd;
    }
    public void SetProperty(AnimationType animationType,Character character, float value, bool ifWaitUntilEnd)
    {
        this.character=character;
        this.animationType = animationType;
        this.fvalue = value;
        this.isWaitUntilEnd = ifWaitUntilEnd;
    }
}
public enum AnimationType{
    Attack,
    Attacked,
    TakeDamage
}


