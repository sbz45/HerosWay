using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIUpdater : MonoBehaviour
{
    public static UIUpdater instance ;

    public TabUpdateManager tabUpdateManager;
    public DiceUpdateManager DiceUpdateManager;
    public StatusBarController statusBarController;

    public FightManager fightPanelManager;
    public void Awake()
    {
        instance = this;





    }
    
    public void UpdateSkillBar(Skill[] skills)
    {
        tabUpdateManager.UpdateSkills(skills);
    }
    public void UpdateStatusBar(Character character)
    {
        statusBarController.UpdateState(character);
    }
    
    public void UpdateDice(Dice dice)
    {
        DiceUpdateManager.UpdateDice(dice);
    }

}
