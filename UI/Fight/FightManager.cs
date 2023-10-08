using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

/// <summary>
/// it manages the state panel update during  fight
/// </summary>
public class FightManager : MonoBehaviour
{
    //manages Buff{roundEnd};FightEvent{FightStart,End}.others are managed by character itself
    

    public static FightManager instance;
    public GameObject mainGame;
    private Player player;
    private Enemy enemy;
    public FightPanelcontroller fightPanelcontroller;
    /// <summary>
    /// if false ,normal attack and skill will NOT work
    /// </summary>
    public bool playerAttackActive=false;
    public GameObject fightPanel;
    private WaitForSeconds WaitFor1Second = new WaitForSeconds(1);
    /// <summary>
    /// -1 for ordinaryatk
    /// </summary>
    private List<int> skillReleased=new List<int>();
    private FightRoundHandler fightRoundHandler;
    public  void Awake()
    {
        playerAttackActive = false;
        instance = this;
        fightRoundHandler=new FightRoundHandler();
    }
    public bool isSkillReleased(int i)
    {
        return skillReleased.Contains(i);
            
    }
    public IEnumerator FightStart(List<Character> characters)
    {
        Debug.Log("fightStart");
        player = GameManager.instance.player;
        enemy = GameManager.instance.enemy;
        player.opponent = enemy;
        enemy.opponent = player;
        enemy.FightStartInitialization();
        player.FightStartInitialization();
        foreach (var i in characters) FightEventListener.CharacterEnterStage(i);


        skillReleased.Clear();
        
        //fightPanelcontroller.CharacterUpdate();//���ﷸ��һ���ش�ʧ����ǰȥ���½�ɫ������fightpanel��û׼����
        yield return StartCoroutine( fightPanelcontroller.EnterSrceen());
        StartCoroutine(MainLoop());

    }

    private IEnumerator MainLoop()
    {
        WaitUntil waitUntilPlayerAttacked=new WaitUntil(()=>!playerAttackActive);
        Character characterInAction=player;
        while (true)
        {
            yield return StartCoroutine(RoundStartHandeler(characterInAction));
            if(characterInAction.characterType==CharacterType.enemy)
            {
                yield return StartCoroutine(EnemyAttack(characterInAction.dice.currentPoint));
            }else
            {
                yield return waitUntilPlayerAttacked;
            }
            yield return StartCoroutine(RoundEndHandeler(characterInAction));
            if(CheckFightEnd())yield break;
            yield return  StartCoroutine( fightRoundHandler.GetNextToAction(characterInAction));
        }
    }
    #region roundStart
    public IEnumerator RoundStartHandeler(Character character)
    {
        character.RoundStartTakeEffectBuff();
        int dicePoint;
        if (character.characterType == CharacterType.enemy)
        {
            Debug.Log("RoundStartHandelerenemy");
            character.dice.GetNumber();
            FightEventListener.DiceTrown(character.dice, character);
            dicePoint = character.dice.currentPoint;
            yield return WaitFor1Second;
            
            
            
            
        }
        else
        {
            Debug.Log("RoundStartHandelerPlayer");
            character.dice.GetNumber();
            FightEventListener.DiceTrown(character.dice, character);
            dicePoint = character.dice.currentPoint;
            yield return WaitFor1Second;
            //DiceUpdate
            /* fightPanelcontroller.PlayerUpdate();*/
            fightPanelcontroller.SetSkillBoxActive(dicePoint);
            playerAttackActive = true;
        }
    }
    #endregion
    #region Attacking phase
    public IEnumerator EnemyAttack(int dicePoint)
    {
        Debug.Log("EnemyAttack");
        
        yield return FightAnimationHandeler.instance.AttackAnimation(enemy.SkillAttack(dicePoint));
        yield return WaitFor1Second;
        fightPanelcontroller.PlayerUpdate();
       
        
        
    }
    public void PowerUp()
    {
        player.dice.currentPoint++;
        fightPanelcontroller.SetSkillBoxActive(player.dice.currentPoint);
        Debug.Log("PowerUped :" + player.dice.currentPoint.ToString());
    }
    //this method is called by UI click
    public IEnumerator SkillUnleash(Skill skill)
    {
        Debug.Log("SkillUnleash");
        /* if (playerAttackActive != true) return;*/
        /*  playerAttackActive = true;*/
        fightPanelcontroller.SetSkillBoxActive(-1);
        skillReleased.Add(skill.index);
         yield return FightAnimationHandeler.instance.AttackAnimation(player.SkillAttackByIndex(skill));
        yield return WaitFor1Second;
        fightPanelcontroller.CharacterUpdate();

        
         
    }
    public IEnumerator NormalAttackUnleash()
    {
        Debug.Log("NormalAttackUnleash");
        fightPanelcontroller.SetSkillBoxActive(-1);
        skillReleased.Add(-1);
        yield return FightAnimationHandeler.instance.AttackAnimation(player.OrdinaryAttack(player.dice.currentPoint));
        yield return WaitFor1Second;
        fightPanelcontroller.EnemyUpdate();

       
        
    }
    #endregion
    #region roundEnd
    public IEnumerator RoundEndHandeler(Character character)
    {
        Debug.Log("RoundEndHandeler");
        character.RoundEndTakeEffectBuff();
        character.UpdateOldBuff();
        yield return WaitFor1Second;
        fightPanelcontroller. CharacterUpdate();
        player.dice.SetDefault();
        fightPanelcontroller.DicePanelUpdate(player.dice);

    }
    #endregion
    #region Fight End

    public bool CheckFightEnd()
    {
        if (player.health <= 0)
        {
            FightEnd(player);
            return true;
        }
        else if (enemy.health <= 0)
        {
            FightEnd(enemy);
            return true;
        }
        return false;
    }
    public void FightEnd(Character characterLose)
    {
        FightEventListener.FightEnd(characterLose, characterLose.opponent);
        player.ClearAllBuff();
        enemy.ClearAllBuff();
       /* FightEventListener.ResetAllEvent();*/
        player.opponent = null;
        enemy = null;
        if (characterLose.characterType == CharacterType.enemy)
        {
            Debug.Log("You Win");
        }
        else
        {
            Debug.Log("You Lose");
        }
        
    }
    #endregion 
}
