using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
[CreateAssetMenu]
 public class SkillDistributor : ScriptableObject
{
    public List<Skill> skillPot;

    private void Awake()
    {
        Initialize();
    }
    public void Initialize()
    {
        skillPot.Clear();
        var Skills = Resources.LoadAll<Skill>("Skills/Knight");
        foreach (var t in Skills)
        {
            skillPot.Add(t);
        }
        Sprite DefaultSprite= Resources.Load<Sprite>("0");
        foreach (var i in skillPot)
        {
            i.icon = DefaultSprite;


        }  
        foreach(var i in skillPot)
        {
            i.index = skillPot.IndexOf(i);
        }
    }
    public Skill[] GetThreeSkill()
    {

        Skill[] skills = new Skill[3];
        for(int  i = 0; i < 3; i++)
        {
            while (skills[i] == null)
            {
                bool isQualified=true;
                int listIndex=UnityEngine.Random.Range(0, this.skillPot.Count);
                int skillIndex = this.skillPot[listIndex].index;
                foreach(Skill t in GameManager.instance.player.skills)
                {
                    if (t == null) continue;
                    if (t.index== skillIndex)
                    {
                        isQualified = false;
                        break;
                    }
                }
                foreach (Skill t in skills)
                {
                    if (t == null) continue;
                    if (t.index == skillIndex)
                    {
                        isQualified = false;
                        break;
                    }
                }
                if (!isQualified) continue;
                skills[i] = this.skillPot[listIndex];
            }
            
        }
        return skills;
    }
}
