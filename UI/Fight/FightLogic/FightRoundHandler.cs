using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;
using UnityEngine.UI;

public class FightRoundHandler : MonoBehaviour
{
    List<Character> fighters;
    /// <summary>
    /// 0->100
    /// </summary>
    Dictionary<Character, float> positionInActonBar;
    Dictionary<Character, Image> iconInActonBar;
    [SerializeField] Image actionBar;
    [SerializeField] GameObject characterIconPrefab;

     void Awake()
    {
        FightEventListener.OnCharacterEnterStage += RegisterFighter;
        FightEventListener.OnCharacterLeaveStage += EliminateFighter;
        FightEventListener.OnFightStart += ClearActionBar;
        FightEventListener.OnFightEnd += ClearActionBar;

        fighters = new List<Character>();
        positionInActonBar = new Dictionary<Character, float>();
        iconInActonBar = new Dictionary<Character, Image>();
    }
    public void ClearActionBar(Character character,Character character1)
    {
        fighters.Clear();
        positionInActonBar.Clear();
        iconInActonBar.Clear();
    }
    public void RegisterFighter(Character character)
    {
        fighters.Add(character);
        positionInActonBar.Add(character, 0);
        Image image = new GameObject("Icon" + character.name).AddComponent<Image>();
        image.rectTransform.parent = actionBar.rectTransform;
        image.sprite = character.iconCharacter;
        image.rectTransform.anchoredPosition = new Vector2(-actionBar.rectTransform.rect.width/2, 0);
        image.rectTransform.localScale = new Vector3(1, 1, 1);
        iconInActonBar.Add(character, image);
        
    }
    public void EliminateFighter(Character character)
    {
        fighters.Remove(character);
        positionInActonBar.Remove(character);
        Destroy( iconInActonBar[character].gameObject);
        iconInActonBar.Remove(character);
        
    }
    public float GetNextToAction(ref Character character)
    {
        //reset position before start
        foreach (var i in positionInActonBar)
        {

            MoveToPositionInActionBarByPercentage(i.Key, positionInActonBar[i.Key]);
        }
        float timeForNextAction = -1;
        Character nextToAction = null;
        foreach (var i in positionInActonBar)
        {
            float time = (100 - i.Value) / i.Key.speed;
            if (time < timeForNextAction || timeForNextAction == -1)
            {
                timeForNextAction = time;
                nextToAction = i.Key;
            }
        }
        
        foreach(var i in fighters)
        {
            positionInActonBar[i] += i.speed * timeForNextAction;
            if (positionInActonBar[i] > 100) Debug.Log("GetNextToAction" + i.characterName.ToString());
        }
           
        
        if (timeForNextAction == -1)
        {
            Debug.Log("GetNext To Action Error");
            return -1;
        }
        ActionBarAnimation(nextToAction, timeForNextAction);
        positionInActonBar[nextToAction] = 0;
        character = nextToAction;
        return timeForNextAction;
    }
    private void ActionBarAnimation(Character character, float time)
    {

        foreach (var i in positionInActonBar)
        {

            MoveToPositionInActionBarByPercentage(i.Key, positionInActonBar[i.Key], time);
        }
    }
    private void MoveToPositionInActionBarByPercentage(Character character, float percent, float time)
    {
        iconInActonBar[character].rectTransform.DOAnchorPosX(
            percent * actionBar.rectTransform.rect.width * actionBar.rectTransform.localScale.x/100
            -actionBar.rectTransform.rect.width / 2

            , 1f).SetEase(Ease.Linear); 
    }
    private void MoveToPositionInActionBarByPercentage(Character character, float percent)
    {
        iconInActonBar[character].rectTransform.anchoredPosition = new Vector2(
            percent * actionBar.rectTransform.rect.width * actionBar.rectTransform.localScale.x/100
            - actionBar.rectTransform.rect.width / 2
            , 
            iconInActonBar[character].rectTransform.anchoredPosition.y
            );
            
    }
    /// <summary>
    /// distance range from 0 to 100
    /// </summary>
    /// <param name="character"></param>
    /// <param name="distance"></param>
    public void MoveInActionBarByDistance(Character character, float distance)
    {
        positionInActonBar[character] += distance;
        Mathf.Clamp(positionInActonBar[character], 0, 100);
    }
    /// <summary>
    /// percent range from 0 to 1
    /// </summary>
    /// <param name="character"></param>
    /// <param name="percent"></param>
    public void MoveInActionBarByPercent(Character character, float percent)
    {
        positionInActonBar[character] += percent* positionInActonBar[character];
        Mathf.Clamp(positionInActonBar[character], 0, 100);
    }
}
