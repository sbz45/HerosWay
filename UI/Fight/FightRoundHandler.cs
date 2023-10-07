using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using UnityEngine.UI;

public class FightRoundHandler : MonoBehaviour
{
    List<Character> fightersTransform;
    /// <summary>
    /// 0->100
    /// </summary>
    Dictionary<Character,float>positionInActonBar;
    Dictionary<Character, Image> iconInActonBar;
    [SerializeField] Canvas actionBar;
    [SerializeField] GameObject characterIconPrefab;
    public void RegisterFighter(Character character){
        fightersTransform.Add(character);
        positionInActonBar.Add(character,0);
        Image image  =new GameObject("Icon"+character.name).AddComponent<Image>();
        image.transform.parent = actionBar.transform;
        MoveFightPosition(character, positionInActonBar[character]);
    }
    public IEnumerator GetNextToAction(Character character){
        float timeForNextAction=-1;
        Character nextToAction=null;
        foreach(var i in positionInActonBar){
            float time=(100-i.Value)/i.Key.speed;
            if(time<timeForNextAction||timeForNextAction==-1)timeForNextAction=time;
            nextToAction=i.Key;
        }
        foreach(var i in positionInActonBar){
            positionInActonBar[i.Key]=i.Value+i.Key.speed*timeForNextAction;
            if(positionInActonBar[i.Key]>100)Debug.Log("GetNextToAction");
        }
        yield return StartCoroutine(ActionBarAnimation(nextToAction));
        positionInActonBar[nextToAction]=0;
        character= nextToAction;
        
    }
    private IEnumerator ActionBarAnimation(Character character)
    {
        foreach(var i in positionInActonBar)
        {
            MoveToPositionInActionBarByPercentage(i.Key, positionInActonBar[i.Key]);
        }
    }
    private void MoveToPositionInActionBarByPercentage(Character character ,float percent)
    {
        iconInActonBar[character].rectTransform.DOAnchorPosX(percent* actionBar.);
    }
    public void MoveFightPosition(Character character,float distance){
        positionInActonBar[character]+=distance;
        Mathf.Clamp(positionInActonBar[character],0,100);
    }
}
