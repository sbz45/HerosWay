using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static Item;

public class ItemUI : MonoBehaviour,IPointerClickHandler,IPointerEnterHandler
{
    public Sprite icon;
    public new  string name;
    public string description;
    public ItemType type;
    public Object descriptionPrefab;
    public int index;
    public void OnPointerClick(PointerEventData eventData)
    {
        Player.instance.bag.PopItem(index);
       
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Object o=Instantiate(descriptionPrefab, transform.position,Quaternion.identity);
        o.GetComponent<Text>().text = description;
        
    }

    // Start is called before the first frame update
    void Awake()
    {
        icon = GetComponent<SpriteRenderer>().sprite;

    }


}
