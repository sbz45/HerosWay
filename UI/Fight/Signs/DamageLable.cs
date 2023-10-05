using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
public class DamageLable : MonoBehaviour
{
    [SerializeField]  Color colorPhysicalAtk;
    [SerializeField]  Color colorSpirituyalAtk;
    [SerializeField]TextMeshProUGUI damageText;
    private void Awake()
    {
        Close();
    }
    public IEnumerator Show(int damage,DamageType damageType )
    {
        
        
        damageText.text = damage.ToString();
        if (damageType == DamageType.spiritual)
        {
            yield return damageText.DOColor(colorSpirituyalAtk, 0).WaitForCompletion();
        }
        else if(damageType == DamageType.physical)
        {
            yield return  damageText.DOColor(colorPhysicalAtk, 0).WaitForCompletion();
        }

        this.gameObject.transform.DOMoveY(transform.position.y + (float)50, (float)2, false).SetEase(Ease.OutQuad).OnComplete(
            () => this.gameObject.transform.DOMoveY(transform.position.y - (float)50, 0, false).OnComplete(Close)
            );
           
       



    }
    private void Close()
    {
        damageText.text = string.Empty;
    }
}
public enum DamageType
{
    physical,
    spiritual
}
