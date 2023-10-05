using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;
using TMPro;
public class StatusBarController : MonoBehaviour
{
    public Image healthBar;
    public Image sansBar;
    public Image defence;
    public GameObject BuffBar;
    public BuffBoxManager BuffPrefab;
    [SerializeField] TextMeshProUGUI healthText;
    [SerializeField] TextMeshProUGUI sansText;
    

    /// <summary>
    /// health and sans
    /// </summary>
    /// <param name="character"></param>
    public void UpdateState(Character character)
    {
        DOTween.To(() => healthBar.fillAmount, x => healthBar.fillAmount = x, (float)character.health / character.HEALTH, 1).SetEase(Ease.InOutSine);
        DOTween.To(() => sansBar.fillAmount, x => sansBar.fillAmount = x, (float)character.sans / character.SANS, 1).SetEase(Ease.InOutSine);
        DOTween.To(() => defence.fillAmount, x => defence.fillAmount = x, (float)character.defence / character.HEALTH, 1).SetEase(Ease.InOutSine);
        
        if(character.defence!=0) healthText.text = character.health.ToString()+'+'+character.defence+'/'+character.HEALTH;
        else healthText.text = character.health.ToString()  + '/' + character.HEALTH.ToString();
        sansText.text = character.sans.ToString() + '/' + character.SANS.ToString();

    }
    public void UpdateBuffBar(List<Buff> buffs)
    {
        
        var children = BuffBar.transform.GetComponentsInChildren<BuffBoxManager>();
        foreach (var child in children)
        {
             Destroy(child.gameObject); 

        }
        foreach (var buff in buffs)
        {
            var newBuff = Instantiate(BuffPrefab, BuffBar.transform);
            newBuff.UpdateBuffBox(buff);
        }
    }
}
