using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class StageCurtain : MonoBehaviour
{
    public  UnityEngine.UI.Image  curtain;

    private Vector2 defultPosition;
    private Vector2 leftToScreen;
    private Vector2 upToScreen;
    private Vector2 rightToScreen;
    private Vector2 downToScreen;
    private void Awake()
    {
        curtain.color = Color.clear;
        defultPosition = transform.position;
        leftToScreen = new Vector2 (transform.position.x - Screen.width,transform.position.y);
        upToScreen = new Vector2(transform.position.x, transform.position.y + Screen.width);
        rightToScreen = new Vector2(transform.position.x + Screen.width, transform.position.y);
        downToScreen = new Vector2(transform.position.x , transform.position.y - Screen.width);


    }
    public void LightOff()
    {
        curtain.color = Color.black;
        
    }
    public void LightUp()
    {
        curtain.color = Color.clear;
    }
    /// <summary>
    /// darken the curtain,cover the stage
    /// </summary>
    public void FadeOut()
    {
        DOTweenModuleUI.DOFade(curtain, 1, 1.5f);
        
    }
    /// <summary>
    /// show the stage
    /// </summary>
    public void FadeIn()
    {
        DOTweenModuleUI.DOFade(curtain, 0, 1.5f);
    }
    public void SlideIn()
    {
        curtain.transform.position = leftToScreen;
        curtain.color = Color.black;
        curtain.transform.DOMove(defultPosition, 0.5f);
    }
    public void SlideOut()
    {
        curtain.transform.DOMove(rightToScreen,0.5f);
        curtain.color = Color.clear;
        curtain.transform.position = defultPosition;
    }
    #region flash
    /// <summary>
    /// white screen
    /// </summary>
    /// <param name="flashTimes"></param>
    public void Flash(int flashTimes)
    {


        StartCoroutine(m_Flash(flashTimes));
        
    }
    WaitForSeconds WaitFor005 = new WaitForSeconds(0.05f);
    WaitForSeconds WaitFor03 = new WaitForSeconds(0.3f);
    private IEnumerator m_Flash(int flashTimes)
    {
        while (flashTimes-- != 0)
        {
            Color color = curtain.color;
            curtain.color = Color.white;
            yield return WaitFor005;
            curtain.color= color;
            yield return WaitFor03;


        }
    }
    #endregion
}