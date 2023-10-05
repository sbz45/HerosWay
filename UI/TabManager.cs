using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabManager : MonoBehaviour
{
    public GameObject[] tabs;

    public void OnTabButtonClick(int index)
    {
    for(int i = 0; i < tabs.Length; i++)
        {
            tabs[i].SetActive ( false);
            if(index==i) tabs[i].SetActive(true);
        }
    }
}
