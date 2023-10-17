using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class MissionPrefab : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI title;
    [SerializeField] TextMeshProUGUI description;
    [SerializeField] GameObject rewardContainer;
    [SerializeField] RewardBox RewardPrefab;
    public Mission mission{get;set;}
    public MissionPrefab UpdateMission(Mission mission)
    {
        this.mission = mission;
        title.text = mission.MissionName;
        description.text = mission.MissionDescription;
        foreach (var i in rewardContainer.GetComponentsInChildren<Transform>()) Destroy(i.gameObject);
        foreach (var i in mission.rewards) Instantiate(RewardPrefab.SetReward(i), rewardContainer.transform);

        return this;
    }
}
