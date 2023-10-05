using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiceUpdateManager : MonoBehaviour
{
    public Image icon;
    public Text nameDice;
    public GameObject descriptionBox;
    public Text description;
    public Image[] images=new Image[6];
    public Sprite[] surfaceSprites = new Sprite[6];
    public void UpdateDice(Dice dice)
    {
        icon.sprite = dice.icon;
        nameDice.text = dice.diceName;
        description.text = dice.diceDescription;
        for(int i = 0; i < dice.diceSurface.Length; i++)
        {
            images[i].sprite = surfaceSprites[dice.diceSurface[i]];
        }
    }
    public void OnPointerStay()
    {
        descriptionBox.SetActive(true);
        Debug.Log("true");
    }
    public void OnPointerExit()
    {
        descriptionBox.SetActive(false);
        Debug.Log("false");
    }
}
