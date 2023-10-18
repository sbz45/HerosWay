using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public  Player player;
    //variables for fight 
    public bool isFighting;
    public Enemy enemy;
    public FightManager fightManager;
    
    [SerializeField] StageCurtain StageCurtain;
    public UIUpdater UIUpdater;
    private void Awake()
    {
        instance = this;
        UIUpdater.Awake();
        fightManager.Awake();
    }
    public void FightStart(Player player,Enemy enemy)
    {

        isFighting = true;
        this.player = player;
        this.enemy = enemy;
        fightManager.fightPanel.SetActive(true);
        List<Character> characters = new List<Character>();
        characters.Add(player);
        characters.Add(enemy);
        StartCoroutine( fightManager.FightStart(characters));

    }
    public void FightEnd(Player player, Enemy enemy)
    {
        isFighting = false;
        this.player = player;
        this.enemy = enemy;
        fightManager.fightPanel.SetActive(false);
        /*StartCoroutine(fightManager.FightStart());*/

    }

}
