using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack 
{
    public Character attacker;
    public Character attacked;
    public string attackName;
    public int damagePhysical;
    public int damageSpiritual;
    public float ignorePhysicalResistance;
    public float ignoreSpiritualResistance;

    public List<Buff> buffsAttached;
    /*public List<SpecialEffect> specialEffectAttached;*/
    public Attack()
    {
        attackName = "ÆÕÍ¨¹¥»÷";
        damagePhysical = 0;
        damageSpiritual = 0;
        ignorePhysicalResistance = 0;
        ignoreSpiritualResistance = 0;
        buffsAttached = new List<Buff>();
        /*specialEffectAttached = new List<SpecialEffect>();*/
    }
    /// <summary>
    /// this.attacker = attacker;
    ///   this.attacked = attacked;
    /// attackName = "ÆÕÍ¨¹¥»÷";
    /// damagePhysical = 0;
    /// damageSpiritual = 0;
    /// ignorePhysicalResistance = 0;
    /// ignoreSpiritualResistance = 0;
    ///  buffsAttached.Clear();
    ///  
    /// </summary>
    /// <param name="attacker"></param>
    /// <param name="attacked"></param>
    
    public void Initialize(Character attacker, Character attacked)
    {

        this.attacker = attacker;
        this.attacked = attacked;
        attackName = "ÆÕÍ¨¹¥»÷";
        damagePhysical = 0;
        damageSpiritual = 0;
        ignorePhysicalResistance = 0;
        ignoreSpiritualResistance = 0;
        buffsAttached.Clear();
        /*specialEffectAttached.Clear();*/
    }
}

