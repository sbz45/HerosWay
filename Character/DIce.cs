using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dice : ScriptableObject
{
    public Sprite icon;
    public int[] diceSurface = new int[6];
    public string diceDescription;
    public string diceName;
    public int currentPoint;
    //���캯����createInstance��ʱ��Ҳ�����Զ�new
    public Dice()
    {
        diceName = "��ͨ����";
        diceDescription = "��ʵ�޻���ʵ��";

    }
    /// <summary>
    /// 0,1,2,3,4,5
    /// 
    /// </summary>
    /// <returns></returns>
    public int GetNumber()
    {
        int surfaceIndex=Random.Range(0, 6);
        currentPoint = surfaceIndex;
        return currentPoint;

        /*return diceSurface[surfaceIndex];*/
    }
    /// <summary>
    /// set currentpoint to -1
    /// </summary>
    public void SetDefault()
    {
        currentPoint = -1;
    }
    /*public void CarveSurface(int curvedIndex,int toCurveIndex)
    {
        diceSurface[curvedIndex] = toCurveIndex;
    }*/
    
}
