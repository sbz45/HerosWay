using JetBrains.Annotations;

using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEditor.ShaderGraph.Serialization;
using UnityEngine;

public class Character : MonoBehaviour
{
    public String characterName;
    private  Attack AttackSingleton = new Attack();
    public CharacterType characterType;
    public Sprite iconCharacter;
    public Animator animator;

    public int attack;
    public int defence;
    public int speed;
    public int health;
    public int sans;
    public int diceMultiply;
    public int HEALTH;
    public int ATTACK;
    public int DEFENCE;
    public int SPEED;
    public int SANS;
    public int DICEMULTIPLY;

    //resistance
    public float physicalAttackResistance;
    public float spiritAttackResistance;
    public float PHYSICALATTACKRESISTANCE;
    public float SPIRITATTACKRESISTANCE;
   public   Skill[] skills;
    public Ability[] abilitys;
    public List<Buff> buffs;
    public List<SpecialEffect> specialEffects;
    public Dice dice;
    private Character _opponent;
    public Character opponent { get { return GetOpponent(); } set { _opponent = value; }}

    public  void Awake()
    {
        

            Debug.Log("CharacterAwake");
            
            
            
            skills = new Skill[6];
            abilitys = new Ability[5];
            

            
       
        dice = Dice.CreateInstance<Dice>();
    }
    public Character GetOpponent()
    {
        if (_opponent == null)
        {
            if (characterType == CharacterType.enemy) return GameManager.instance.player;
            else return GameManager.instance.enemy;
        }else
        {
            return _opponent;
        }
       
            }
    /// <summary>
    /// set fightTimeAttributeVariables To Default
    /// </summary>
    public void FightStartInitialization()
    {
              attack=ATTACK;
      defence=DEFENCE;
      speed=SPEED;
      
      diceMultiply=DICEMULTIPLY;


    
      physicalAttackResistance=PHYSICALATTACKRESISTANCE;
      spiritAttackResistance=SPIRITATTACKRESISTANCE;

}
    #region skillMangement
    /// <summary>
    /// create A copy of current skills(in case of the change in ScriptableObject),and set the owner to character
    /// </summary>
    public void RegisterAllSkills()
    {
        for(int i=0; i<skills.Length;i++)
        {
           /* if (skills[i] == null) continue;
            Skill newSkill = (Skill)ScriptableObject.CreateInstance(skills[i].GetType().ToString());
            skills[i].Copy(newSkill);*/
            var clone = Instantiate(skills[i]);
            skills[i] = clone;
            skills[i].skillDescription += "modified";
            skills[i].RegisterOwner(this);

        }
    }
    public bool LearningSkill(Skill skill)
    {
        foreach (Skill s in this.skills)
        {
            if (s == null) continue;
            if (s.index == skill.index)
            {
                Debug.Log("Duplicate Skill");
                return false;
            }
        }
        //find the first column available
        int i;
        for (i = 0; i < skills.Length; i++)
        {

            if (skills[i] == null)
            {


               /* Skill newSkill = (Skill)ScriptableObject.CreateInstance(skill.GetType().ToString());
                skill.Copy(newSkill);*/
                skills[i] = Instantiate(skill);
                skills[i].RegisterOwner( this);
                break;
            }
        }
        UpdateSkillUI();
        //if the skill bar is full,we need to let player forget one
        if (i == skills.Length)
        {
            return false;

        }
        return true;
    }
    public bool isSkillsEmpty()
    {
        foreach (var i in skills)
        {
            if (i != null) return false;
        }
        return true;
    }
    public void UpdateSkillUI()
    {
        UIUpdater.instance.UpdateSkillBar(skills);
    }
    #endregion
    #region Attck&takeAttack

    /// <summary>
    /// THE STD NORMAL ATTACK RELEASER
    /// </summary>
    /// <param name="dicePoint"></param>
    /// <returns></returns>
    public Attack OrdinaryAttack(int dicePoint)
    {
        if (AttackSingleton == null) AttackSingleton = new Attack();
        AttackSingleton.Initialize(this,opponent);
        foreach (Buff i in buffs)
        {
            if (i.isAttacking) i.TakeEffect(this);
        }

        AttackSingleton.damagePhysical = attack + dicePoint * diceMultiply;
        /*AttackSingleton.specialEffectAttached = this.specialEffects;*/

          FightEventListener.CharacterDeliveringAttack(AttackSingleton, this);
        this.opponent.TakeAttack(AttackSingleton);
        foreach (Buff i in buffs)
        {
            if (i.isAttacking) i.DeEffect(this);
        }
        return AttackSingleton;

    }
    /// <summary>
    /// THE STD SKILL RELEASER,BOTH FOR PLAYER AND ENEMY
    /// </summary>
    /// <param name="skill"></param>
    /// <returns></returns>
    public Attack SkillAttackByIndex(Skill skill)
    {

        Skill skillTemp=null;
        foreach (Buff i in buffs)
        {
            if (i.isAttacking) i.TakeEffect(this);
        }

        
        foreach(var i in skills)
        {
            if (i.index == skill.index)
            {
                skillTemp = i;
                AttackSingleton =i.Unleash(this.opponent);
                break;
            }
        }
        if (AttackSingleton.attacked != null&& skillTemp!=null) FightEventListener.CharacterDeliveringSkillAttack(skillTemp, AttackSingleton);
        if (AttackSingleton.attacked != null&&skillTemp != null) AttackSingleton.attacked.TakeAttack(AttackSingleton);
       
        foreach (Buff i in buffs)
        {
            if (i.isAttacking) i.DeEffect(this);
        }

        return AttackSingleton;
    }
    public Attack SkillAttackRandom()
    {

        int surfaceIndex = UnityEngine.Random.Range(0, 6);
        
         return SkillAttack(surfaceIndex);
    }
    /// <summary>
    /// unleash the skill that has the highest cost and is able to be unleashed(for enemy)
    /// </summary>
    /// <param name="dicePoint"></param>
    public Attack SkillAttack(int dicePoint)
    {

        Skill skillToUnleash = null;
        foreach (var i in skills)
        {
            if (i == null) continue;
            if (i.dicePointCost <= dicePoint && (skillToUnleash == null || skillToUnleash.dicePointCost < i.dicePointCost))
            {
                skillToUnleash = i;
            }
        }
        
        if (skillToUnleash != null)
        {
            return SkillAttackByIndex(skillToUnleash);
/*            attack = skillToUnleash.Unleash(opponent);
            FightEventListener.CharacterDeliveringSkillAttack(skillToUnleash, attack);
            attack.attacked.TakeAttack(attack);
             return attack; */
        }            
        else  return OrdinaryAttack(dicePoint);

    }
    public int TakeAttack(int totalAttack)
    {
        totalAttack = (int)(totalAttack * (1 - physicalAttackResistance));
        if (defence > 0)
        {
            defence -= totalAttack;

            if (defence < 0) defence = 0;
            return totalAttack;
        }
        HealthChange(-totalAttack);
        return totalAttack;
    }
    public void TakeAttack(Attack attack)
    {
        foreach (Buff i in buffs)
        {
            if (i.isAttacked) i.TakeEffect(this);
            
        }
        
        //FightEventCall
        FightEventListener.CharacterTakingAttack(attack,this);
        
        
        foreach (Buff i in attack.buffsAttached)
        {
            GetBuff(i);
        }
/*        foreach (SpecialEffect i in attack.specialEffectAttached)
        {
            i.TakeEffect(this);
        }*/
        //take physical damage
        int totalAttack=attack.damagePhysical;
        totalAttack = (int)(totalAttack * (1 - physicalAttackResistance*attack.ignorePhysicalResistance));
        if (defence > 0)
        {
            defence -= totalAttack;

            if (defence < 0) defence = 0;
            
        }
        HealthChange(-totalAttack);
        //take spiritual damage
        totalAttack = attack.damageSpiritual;
        totalAttack = (int)(totalAttack * (1 - spiritAttackResistance * attack.ignoreSpiritualResistance));

        SansChange(-totalAttack);


        foreach (Buff i in buffs)
        {
            if (i.isAttacked) i.DeEffect(this);

        }
    }
    /*    public int TakeSpiritAttack(int totalAttack)
        {


           totalAttack = (int)(totalAttack * (1 - spiritAttackResistance));


            SansChange(-totalAttack);
            return totalAttack;
        }*/
    #endregion


    #region stateChange
    //UI Update  included
    public int HealthChange(int amount)
    {
        health += amount;
        if (health > HEALTH)
        {
            int temp = health;
            health = HEALTH;
            if(amount<0) FightEventListener.CharacterTakingPhysicalDamage(amount - temp + SANS, this);
            UIUpdater.instance.UpdateStatusBar(this);
            return amount - temp + HEALTH;


        }
        else
        {
            if (amount < 0) FightEventListener.CharacterTakingPhysicalDamage(amount, this);
            UIUpdater.instance.UpdateStatusBar(this);
            return amount;
        }
       
        
    }

    public int SansChange(int amount)
    {
        sans += amount;
        if (sans > SANS)
        {
            int temp = sans;
            sans = SANS;
            if (amount < 0) FightEventListener.CharacterTakingSpiritualDamage(amount - temp + SANS, this);
            UIUpdater.instance.UpdateStatusBar(this);
            return amount - temp + SANS;


        }
        else
        {
            if (amount < 0) FightEventListener.CharacterTakingSpiritualDamage(amount, this);
            UIUpdater.instance.UpdateStatusBar(this);
            return amount;
        }

        
    }
    public void DefenceChange(int amount)
    {
        defence += amount;
    }

    #endregion

    #region Buff
    public void GetBuff(Buff buffScriptableObject)
    {
        Buff buff = buffScriptableObject.GetCopy();
        buff.RegisterOwner( this);
        if (buff.isStackable)
        {
            foreach (var b in buffs)
            {
                if (b.index == buff.index)
                {
                    b.DeEffect(this);

                    b.duration = buff.duration;
                    b.level += buff.level;
                    if (buff.isState) buff.TakeEffect(this);
                    return;
                }
            }
        }
        else
        {
            foreach (var b in buffs)
            {
                if (b.index == buff.index)
                {
                    b.duration += buff.duration;

                    return;
                }
            }
        }


        //find first column empty and fill in
        buffs.Add(buff);
        //if buff bar is full,omit the oldest one
        /*        if (i == buffs.Length)
                {
                    buffs[0].DeEffect(this);
                    for (i = 0; i < buffs.Length; i++)
                    {
                        if (i != buffs.Length - 1)
                        {
                            buffs[i] = buffs[i + 1];
                        }
                        else
                        {
                            buffs[i] = buff;
                        }

                    }
                }*/

    }
    /// <summary>
    /// --the duration ,if durantion < 0 ,clear the buff
    /// </summary>
    public void UpdateOldBuff()
    {
        List<Buff> buffstoBeRemoved=new List<Buff>();
        foreach (var b in buffs)
        {
            if (--b.duration == 0)
            {
                b.DeEffect(this);
                buffstoBeRemoved.Add(b);
            }

        }
        foreach(var i in buffstoBeRemoved)
        {
            buffs.Remove(i);
        }
    }
    public void ClearAllBuff()
    {

        foreach (var i in buffs)
        {
            i.DeEffect(this);
        }
        buffs.Clear();
    }
    public void ClearBuffForType(BuffType type)
    {

        for (int i = 0; i < buffs.Count; i++)
        {
            if (buffs[i] == null) break;
            if (buffs[i].type == type)
            {
                buffs[i] = null;

                //sort other buffs left
                for (int j = i + 1; j < buffs.Count; j++)
                {
                    if (buffs[j] != null) buffs[j - 1] = buffs[j];
                }
            }
        }

    }
    //for the UnState buff
    public void RoundEndTakeEffectBuff()
    {
        foreach (var b in buffs)
        {
            if (b.isRoundEnd) b.TakeEffect(this);
        }
    }
    public void RoundStartTakeEffectBuff()
    {
        foreach (var b in buffs)
        {
            if (b.isRoundStart) b.TakeEffect(this);
        }
    }

    #endregion Buff
    public void GetSpecialEffect(SpecialEffect specialEffect)
    {
        foreach(SpecialEffect i in specialEffects)
        {
            
            if (i.index == specialEffect.index) return;
        }
        specialEffects.Add(specialEffect);
    }
    public void RemoveSpecialEffect(SpecialEffect specialEffect)
    {
        foreach (SpecialEffect i in specialEffects)
        {

            if (i.index == specialEffect.index) specialEffects.Remove(i);
            /*if (i == specialEffect) specialEffects.Remove(i);*/
        }
    }






}



public enum CharacterType
{
    enemy,
    fighter,
    hunter,
    knight
}

