using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BuffBoxManager : MonoBehaviour
{
    
    
    public Image BuffIcon;
    public Sprite DeafaultIcon;

   

    //information box
    public GameObject InformationBox;
    public TextMeshProUGUI buffDescription;
    public TextMeshProUGUI buffName;
    public TextMeshProUGUI levelLabel;
    public TextMeshProUGUI duration;
    public Buff buff;

    public void UpdateBuffBox(Buff buff)
    {

        this.buff = buff;

        if (buff.buffIcon != null) BuffIcon.sprite = buff.buffIcon;
        buffDescription.text = buff.buffDescription;
        buffName.text = buff.buffName;
        duration.text = buff.duration.ToString();
        if (buff.isStackable)
        {
            levelLabel.text = buff.level.ToString();
        }
        else
        {
            levelLabel.text = string.Empty;

        }
     }
    public void Start()
    {
        BuffIcon.sprite = DeafaultIcon;

    }


    public void OnPointerEnter()
    {
       
        while(InformationBox.transform.position.y > Screen.height - 120)
        {
            InformationBox.transform.position = new Vector3(
            InformationBox.transform.position.x,
            InformationBox.transform.position.y - 100,
            InformationBox.transform.position.z);
        }

         InformationBox.SetActive(true);
    }
    public void OnPointerExit()
    {
       


        InformationBox.SetActive(false);
    }
    
    public void Fade()
    {
        var images = this.GetComponentsInChildren<Image>();
        foreach (var image in images)
        {
            image.DOFade(0,1);
            
        }
        var texts = this.GetComponentsInChildren<TextMeshProUGUI>();
        foreach (var text in texts)
        {
            text.DOFade(0, 1);
        }
        this.transform.DOShakePosition(1, 1, 10, 20, false);
    }
}
