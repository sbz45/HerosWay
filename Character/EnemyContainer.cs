using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "EnemyContainer", menuName = "CharacterContainer/EnemyContainer", order = 0)]
public class EnemyContainer : ScriptableObject
{
    public string characterName;
    public Sprite iconCharacter;
    public Animator animator;

    public int HEALTH=100;
    public int ATTACK=15;
    public int DEFENCE=15;
    public int SPEED=10;
    public int LUCK=10;
    public int SANS=100;
    public int DICEMULTIPLY=1;

    //resistance

    public float PHYSICALATTACKRESISTANCE=(float)0.1;
    public float SPIRITATTACKRESISTANCE = (float)0.1;
    
    public Skill[] skills=new Skill[6];
    public Ability[] abilitys=new Ability[5];
    public List<Buff> buffs=new List<Buff>();
    /*public List<SpecialEffect> specialEffects=new List<SpecialEffect>();*/
    public Dice dice ;
    public string[] lyricAttack ={ "ɱɱɱ" ,"ɱɱɱɱ" };

    public string[] lyricHit ={ "��ɱɱɱ" , "��ɱɱɱɱ" };
    public string[] lyricMoved ={ "��ɱɱɱ", "��ɱɱɱɱ" };
    //to inspire player
    public string[] lyricCloseToSaved ={ "Ҫ��" , "Ҫ����" };
    public string[] lyricCloseToDeath ={ "Ҫ��", "Ҫ����" };
    //sublimate the fight
    public string[] lyricDeath ={ "��������" , "������" };
    public string[] lyricSaved= { "��������", "������" };

}
