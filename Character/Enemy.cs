using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : Character
{
    
    public EnemyContainer enemyContainer;
    public string[] lyricAttack;

    public string[] lyricHit;
    public string[] lyricMoved;
    //to inspire player
    public string[] lyricCloseToSaved;
    public string[] lyricCloseToDeath;
    //sublimate the fight
    public string[] lyricDeath;
    public string[] lyricSaved;
    
    public new void Awake()
    {


        Debug.Log("EnemyAwake");



        skills = new Skill[6];
        abilitys = new Ability[5];
        if (enemyContainer == null) Debug.Log("enemyContainer loss");
          else  LoadContainer(enemyContainer);
        RegisterAllSkills();

       
       
    }
    public void LoadContainer(EnemyContainer enemyContainer)
    {

        characterName = enemyContainer.characterName;
        iconCharacter = enemyContainer.iconCharacter;
        animator = enemyContainer.animator;
        sans= enemyContainer.SANS;
        health = enemyContainer.HEALTH;
        HEALTH = enemyContainer.HEALTH;
        ATTACK = enemyContainer.ATTACK;
        DEFENCE = enemyContainer.DEFENCE;
        SPEED = enemyContainer.LUCK;
        SANS = enemyContainer.SANS;
        DICEMULTIPLY = enemyContainer.DICEMULTIPLY;
        
        PHYSICALATTACKRESISTANCE = enemyContainer.PHYSICALATTACKRESISTANCE;
        SPIRITATTACKRESISTANCE = enemyContainer.SPIRITATTACKRESISTANCE;
        
        skills = (Skill[])enemyContainer.skills.Clone();
        abilitys = (Ability[])enemyContainer.abilitys.Clone();
        buffs .AddRange (enemyContainer.buffs.ToArray());
        /*specialEffects.AddRange(enemyContainer.specialEffects.ToArray()); ;*/
        if(dice!=null)
        dice = Instantiate(enemyContainer.dice);
        if (dice == null)dice = Dice.CreateInstance<Dice>();


        lyricAttack = enemyContainer.lyricAttack;
        lyricHit = enemyContainer.lyricHit;
        lyricMoved = enemyContainer.lyricMoved;
        lyricCloseToSaved = enemyContainer.lyricCloseToSaved;
        lyricCloseToDeath = enemyContainer.lyricCloseToDeath;
        lyricDeath = enemyContainer.lyricDeath;
        lyricSaved = enemyContainer.lyricSaved;
    
    }
public void RandomAttack()
    {
        int surfaceIndex = Random.Range(0, 6);
        if (skills[surfaceIndex] == null)
        {
            OrdinaryAttack(surfaceIndex);
        }
        else
        {
            SkillAttack(surfaceIndex);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
             GameManager.instance.FightStart(collision.gameObject.GetComponent<Player>(), this);
        }
    }
}