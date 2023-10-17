using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RewardBox : MonoBehaviour
{
    Item item;
    [SerializeField] Image itemIcon;
    [SerializeField] TextMeshProUGUI itemCount;
    [SerializeField] TextMeshProUGUI itemDescription;
    [SerializeField] GameObject itemDescriptionBox;

    private void Awake()
    {
        itemDescriptionBox.SetActive(false);
    }
    public RewardBox SetReward(Item item)
    {
        this . item = item;
        itemIcon.sprite = item.icon;
        itemCount.text = item.count.ToString();
        itemDescription.text = item.description;
        return this;

    }
 
    public void ShowDescription()
    {
        itemDescriptionBox.SetActive(true);
    }
    public void HideDescription()
    {
        itemDescriptionBox.SetActive(false);
    }
}
