using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabUpdateManager : MonoBehaviour
{
    public TabSkillBoxManager[] boxs;

    public void UpdateSkills(Skill[] skills)
    {
        for(int i = 0; i < skills.Length; i++)
        {
            if(skills[i]!=null)boxs[i].UpdateSkillBox(skills[i]);
        }
    }
}
