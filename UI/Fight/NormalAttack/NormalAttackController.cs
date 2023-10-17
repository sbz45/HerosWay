using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NormalAttackController : MonoBehaviour
{
    public bool isactive;
    public Image icon;
    public Sprite idleIcon;
    public Sprite stayIcon;
    public GameObject maskInactive;

    public void SetActive(int dicePoint)
    {
        if (dicePoint >= 0)
        {
            maskInactive.SetActive(false);
            isactive = true;

        }
        if (dicePoint < 0)
        {
            maskInactive.SetActive(true);
            isactive = false;

        }
    }
    public void OnPointerExit()
    {
        icon.sprite = idleIcon;
    }
    public void OnPointerEnter()
    {
        if (isactive) icon.sprite = stayIcon;
    }
    public void OnPointerClick()
    {
        if (isactive)StartCoroutine( FightManager.instance.NormalAttackUnleash());
    }
}
