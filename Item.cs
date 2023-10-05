using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item { 
    public Sprite icon;
    public  string name;
    public  string description;
     public ItemType type;


    public void takeEffect()
    {

    }
}
    public enum ItemType
    {
        Weapon,
        consumable,
        amulet
    }
