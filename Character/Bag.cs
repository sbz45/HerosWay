using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bag 
{
    public static Bag instance;
    private Item[] items;
    public int capacity;
    [SerializeField]private ItemUI[] itemUIs;
    public void Awake()
    {
        instance = this;

        items = new Item[10];
    }

    public void UpdateUI()
    {

    }
    public void pushItem(Item item,int index)
    {

        items[index] = item;
    }
    public void pushItem(Item item)
    {
        int index = CheckEmpty();
        items[index] = item;
    }
    public void PopItem(int index)
    {
        items[index] = null;
    }
    public bool CheckEmpty(int index)
    {

            if (items[index] == null) return true;
            return false;

    }
    public int CheckEmpty()
    {

            for (int i = 0; i < items.Length; i++)
            {
                if (items[i] == null) return i;
            }
            return -1;
      
    }
    
}
