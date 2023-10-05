using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillChest : MonoBehaviour
{
    public SkillDistributor skillDistributor;
    public SkillLearn skillLearnPanel;

    public void Respond()
    {
        Skill[] skills = skillDistributor.GetThreeSkill();
        skillLearnPanel.InstantiatePanel(skills);

    }

}
