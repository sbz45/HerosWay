using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening.Core;
using DG.Tweening;

public class SkillLearn : MonoBehaviour
{
    private  bool isActive;
    private int skillCardSelected;
    private Skill skillSelected;
    public GameObject[] SkillCard;
    public GameObject[] stayEdge;
    public GameObject[] selectedEdge;
    public GameObject OkMask;
    public SkillForget SkillForgetPanel;
    public TabSkillBoxManager[] tabSkillBoxManagers; 
    private Skill[] skills;
    public   SkillLearn()
    {
        isActive = true;
    }
    public void SkillCardSeclected(int index)
    {
        foreach (var i in selectedEdge) i.SetActive(false);
        selectedEdge[index].SetActive(true);
        OkMask.SetActive(false);
        skillSelected = skills[index];
        skillCardSelected = index;
    }
    public void SkillCardStay(int index)
    {

        stayEdge[index].SetActive(true);

    }
    public void SkillCardExit(int index)
    {

        stayEdge[index].SetActive(false);

    }
    public void InstantiatePanel(Skill[] skills)
    {
        if (isActive == false) return;
        isActive = true;
        skillSelected = null;
        OkMask.SetActive(true);
        foreach (var i in selectedEdge) i.SetActive(false);
        this.skills = skills;
        for(int i = 0; i < skills.Length; i++)
        {
            Skill skill = skills[i];
            tabSkillBoxManagers[i].UpdateSkillBox(skill);
        }
        gameObject.SetActive(true);
    }
    public void CancelButtonClick()
    {
        gameObject.SetActive(false);
    }
    public void ConfirmButtonClick()
    {
        if (skillSelected != null && isActive) 
        {
            if (!GameManager.instance.player.LearningSkill(skillSelected)) SkillForgetPanel.Instantiate();
            else
            {
                for(int i = 0; i < SkillCard.Length; i++)
                {
                    if (i != skillCardSelected)
                    {
                        var images = SkillCard[i].GetComponentsInChildren<Image>();
                        foreach(var image in images)
                        {
                            image.DOFade(0, 1);
                        }
                        var texts = SkillCard[i].GetComponentsInChildren<TextMeshProUGUI>();
                        foreach (var text in texts)
                        {
                            text.DOFade(0, 1);
                        }
                        SkillCard[i].transform.DOShakePosition(1, 1, 10, 20, false);
                    }
                }
                isActive = false;
            }

        }
        
    }

}
