using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
public class TabSkillBoxManager : MonoBehaviour
{
    //basic box
    public GameObject maskInactive;
    public GameObject edgeStay;
    public GameObject edgeSelected;
    public Image SkillIcon;
    public Sprite DeafaultIcon;

    public GameObject[] dicePointWheel;
    
    //information box
    public GameObject InformationBox;
    public TextMeshProUGUI skillDescription;
    public TextMeshProUGUI skillName;
    
    public Skill skill;
    /// <summary>
    /// has the box been assigned with skill
    /// </summary>
    private bool isSet=false;
    /// <summary>
    /// when active the skill it contains will unleash when thr box is clicked
    /// </summary>
    public bool isActive=false;
    public void UpdateSkillBox(Skill skill)
    {
        if (maskInactive != null) maskInactive.SetActive(false);
        this.skill = skill;
        isSet = true;
        SkillIcon.sprite = skill.icon;
        skillDescription.text = skill.skillDescription+"  ÏûºÄ£º"+skill.dicePointCost.ToString();
        skillName.text = skill.skillName;

        for (int i = 0; i < 6; i++)
        {
            if (dicePointWheel[0]!=null) dicePointWheel[i].SetActive(skill.dicePointCost==i);
        }

    }
    public void Awake()
    {
       /* SkillIcon.sprite = DeafaultIcon;
       */
    }
    public void DeactivateSkill()
    {
        SkillIcon.DOFade((float)0.5, 1);
        maskInactive?.SetActive(true);
        isActive = false;

    }
    public void ActivateSkill()
    {
        SkillIcon.DOFade((float)1, 1);
        maskInactive?.SetActive(false) ;
        isActive = true;
    }

    public void OnPointerEnter()
    {
        if (isSet && isActive) edgeStay?.SetActive(true); 
        if (isSet) InformationBox.SetActive(true);
    }
    public void OnPointerExit()
    {
        if(edgeStay !=null) edgeStay.SetActive(false);


        InformationBox.SetActive(false);
    }
    public void OnPointerClick()
    {

        if (isSet && isActive)
        {
        edgeSelected.SetActive(true);
          StartCoroutine(  FightManager.instance.SkillUnleash(skill));
        }

    }
    public void Fade()
    {
        var images = this.GetComponentsInChildren<Image>();
        foreach (var image in images)
        {
            image.DOFade(0, 1);
        }
        var texts = this.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in texts)
        {
            text.DOFade(0, 1);
        }
        this.transform.DOShakePosition(1, 1, 10, 20, false);
    }
}
