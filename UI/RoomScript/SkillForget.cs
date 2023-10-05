using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillForget : MonoBehaviour
{
    public int skillSelectedIndex;
    public GameObject[] selectedEdge;
    public TabSkillBoxManager[] tabSkillBoxManager;
    

    public void Instantiate()
    {
        gameObject.SetActive(true);
        for (int i = 0; i < 6; i++)
        {
            if (GameManager.instance.player.skills[i] != null)
            {
                
                tabSkillBoxManager[i].UpdateSkillBox(GameManager.instance.player.skills[i]);
                tabSkillBoxManager[i].gameObject.SetActive(true);
            }
            else
            {
                tabSkillBoxManager[i].gameObject.SetActive(false);
            }
        }
    }
    public void SkillSeclected(int index)
    {
        foreach (var i in selectedEdge) i.SetActive(false);
        selectedEdge[index].SetActive(true);
        skillSelectedIndex = index;
    }
    public void ConfirmButtonClick()
    {
        GameManager.instance.player.skills[skillSelectedIndex] = null;
        tabSkillBoxManager[skillSelectedIndex].Fade();
        gameObject.SetActive(false);
    }
    public void CancelButtonClick()
    {
        gameObject.SetActive(false);
    }
}
