
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEditor.UI;

using UnityEngine;

[CreateAssetMenu(fileName = "SheildSmash", menuName = "Skill/Knight/SheildSmash", order = 0)]
public abstract class Skill : ScriptableObject
{
    protected Character owner;
    [SerializeField] CharacterType CharacterType;
    public int index;
    public Sprite icon;
    /*public int level;*/
    /*public bool[] dicepPoint = new bool[6];*/
    public int dicePointCost;//012345
    /*public CharacterType type;*/
    
    public String skillDescription;
    public String skillName;
    public bool isSingle=false;
    public bool isTarget = true;
    /*public List<Buff> buffs;*/
    /// <summary>
    /// attachbuff时不需要把buff复制后再传递，角色获得buff时自动复制
    /// </summary>
    protected Attack skillAttackInstance;
/*    public float multiplierATTACK;
    public float multiplierDEFENCE;
    public float multiplierHEALTH;
    public float multiplierHealth;*/
/*    public int[] basicDamage =new int[5];*/

    /// <summary>
    /// set the owner
    /// </summary>
    /// <param name="character"></param>
    public void RegisterOwner(Character character)
    {
        owner = character;
    }
    private void InitializeAttackInstance()
    {
        if (skillAttackInstance == null) skillAttackInstance = new Attack();
        skillAttackInstance.Initialize(owner, null);
        skillAttackInstance.attackName = skillName;
        
    }
    public  Attack Unleash(Character target)
    {
        InitializeAttackInstance();
         SkillBody(target);
        //CODE below moved to character
        /*if (skillAttackInstance.attacked != null) FightEventListener.CharacterDeliveringSkillAttack(this, skillAttackInstance);
        if (skillAttackInstance.attacked != null) skillAttackInstance.attacked.TakeAttack(skillAttackInstance);*/
        return skillAttackInstance;
    }
    /// <summary>
    /// set the “attacked”of the skillAttackInstance if it has a target，set necessary attributes
    /// </summary>
    /// <param name="target"></param>
    protected abstract void SkillBody(Character target);
   
    public void Upgrade()
    {
        dicePointCost -= 1;
    }
    /// <summary>
    /// 将本技能的属性赋值给传入的技能
    /// </summary>
    /// <param name="skill"></param>
    public void Copy(Skill skill)
    {
        skill.owner = this.owner;
        skill.dicePointCost = this.dicePointCost;
        skill.index = this.index;
        skill.icon = this.icon;
        skill.skillDescription = this.skillDescription;
        skill.skillName = this.skillName;
        skill.isSingle = this.isSingle;
        skill.isTarget = this.isTarget;
    }
    public Skill DeepClone()//深度拷贝
    {
        using (Stream objectStream = new MemoryStream())
        {
            IFormatter formatter = new BinaryFormatter();
            formatter.Serialize(objectStream, this);
            objectStream.Seek(0, SeekOrigin.Begin);
            return formatter.Deserialize(objectStream) as Skill;
        }
    }


   /* public void DicePointUpgrade(int index)
    {
        dicepPoint[index] = true;
    }
    public void DicePointDegrade(int index)
    {
        dicepPoint[index] = false;
    }*/


}
