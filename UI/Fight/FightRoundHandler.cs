using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class FightRoundHandler : MonoBehaviour
{
    List<Character> fighters;
    /// <summary>
    /// 0->100
    /// </summary>
    Dictionary<Character,float>positionInActonBar;
    public void RegisterFighter(Character character){
        fighters.Add(character);
        positionInActonBar.Add(character,0);
    }
    public Character GetNextToAction(){
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
        positionInActonBar[nextToAction]=0;
        return nextToAction;
    }
    public void MoveFightPosition(Character character,float distance){
        positionInActonBar[character]+=distance;
        Mathf.Clamp(positionInActonBar[character],0,100);
    }
}
