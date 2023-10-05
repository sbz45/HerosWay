using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

using DG.Tweening;
/// <summary>
/// custom text field
/// </summary>
public class TextField : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Image backGround;
    WaitForSeconds waitFor01=new WaitForSeconds((float)0.1);
    public  void Awake()
    {
        
        Deactive();
    }
    public void SetText(string s)
    {
        text.text = s;
    }
    public IEnumerator SetTextOneByOne(string s)
    {
        text.text = string.Empty;
        foreach(char  c in s)
        {
            text.text += c;
            yield return waitFor01;
        }
    }
    public void FadeOut()
    {
        text.DOFade(0, (float)0.1).SetEase(Ease.InSine);
        backGround.DOFade(0, (float)0.1).SetEase(Ease.InSine);
    }
    public void FadeIn()
    {
        Active();
        text.alpha = 0;
        backGround.color = new Color(backGround.color.r, backGround.color.g, backGround.color.b, 0);
        text.DOFade(1, (float)0.1).SetEase(Ease.InSine);
        backGround.DOFade(0, (float)0.1).SetEase(Ease.InSine);


    }
    public void SlideIn()
    {
        Active();
        /*gameObject.transform.DOMoveX(-1, 0, false).From().OnComplete(() => );*/
        gameObject.transform.DOMoveX(1, (float)0.2, false).From();



    }
    public void SlideOut()
    {
        gameObject.transform.DOMoveX(transform.position.x-(float)0.1, (float)0.1, false).OnComplete(Deactive);
        /*.OnComplete(() => gameObject.transform.DOMoveX(1, 0, false).From())*/


    }

    public void PopIn()
    {
        Active();
        gameObject.transform.localScale = new Vector3(0, 0, 0);
        gameObject.transform.DOScale(new Vector3(1, 1, 1), (float)0.3).SetEase(Ease.InSine);
    }
    public void PopOut()
    {
        gameObject.transform.
            DOScale(new Vector3(0, 0, 1), (float)0.3).
            SetEase(Ease.InSine).
            OnComplete(() => gameObject.transform.DOScale(new Vector3(1, 1, 1), 0).OnComplete(

            Deactive));
            
        
            


    }
    public void Deactive()
    {
        gameObject.SetActive(false); 
    }
    public void Active()
    {
        gameObject.SetActive(true);
    }
}
