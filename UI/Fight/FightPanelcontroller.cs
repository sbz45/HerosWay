using Microsoft.Unity.VisualStudio.Editor;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using DG.Tweening;

public class FightPanelcontroller : MonoBehaviour
{
    public GameObject fightPanel;

    private Player player;
    public StatusBarController statusBarPlayerController;
     public UnityEngine.UI.Image playerImage;
    public TabSkillBoxManager[] skillBoxs=new TabSkillBoxManager[6];
    public NormalAttackController normalAttackController ;
    public TextMeshProUGUI playerName;



    private Enemy enemy;
    public StatusBarController statusBarEnemyController;
    public UnityEngine.UI.Image enemyImage;
    public TextMeshProUGUI enemyName;
    

    
    public IEnumerator EnterSrceen() 
    {
        fightPanel.SetActive(true);
        fightPanel.transform.DOBlendableMoveBy(new Vector3(0, Screen.height,0),0);
        fightPanel.transform.DOBlendableMoveBy(new Vector3(0, -Screen.height, 0), (float)0.5);
        player = GameManager.instance.player;
        enemy = GameManager.instance.enemy;
        PlayerUpdate();
        EnemyUpdate();
       
        yield return new WaitForSeconds(1);
    }
    public void OutScreen()
    {
        fightPanel.SetActive(true);
    }
    public void CharacterUpdate()
    {
        PlayerUpdate();
        EnemyUpdate();
    }
    public void PlayerUpdate()
    {
        playerImage.sprite = player.iconCharacter;
        playerName.text = player.characterName;
        statusBarPlayerController.UpdateState(player);
        statusBarPlayerController.UpdateBuffBar(player.buffs);
        for (int i = 0; i < 6; i++)
        {
            if(player.skills[i]!=null)
            skillBoxs[i].UpdateSkillBox(player.skills[i]);
        }

    }
    /// <summary>
    /// set skills and normal attack according to dicepoint
    /// </summary>
    /// <param name="dicePoint"></param>
    public void SetSkillBoxActive(int dicePoint)
    {
        foreach(var i in skillBoxs)
        {
            if (i.skill == null) continue;
            if (dicePoint >= i.skill.dicePointCost)
            {
                if (i.skill.isSingle && FightManager.instance.isSkillReleased(i.skill.index)) continue;
                i.ActivateSkill();
            } 
            else
            {
                i.DeactivateSkill();
            }
        }
        normalAttackController.SetActive(dicePoint);
    }

    public void EnemyUpdate()
    {
        enemyImage.sprite = enemy.iconCharacter;
        enemyName.text = enemy.characterName;
        statusBarEnemyController.UpdateState(enemy);
        statusBarEnemyController.UpdateBuffBar(enemy.buffs);
    }

    public void DicePanelUpdate(Dice dice)
    {

    }
   




}
