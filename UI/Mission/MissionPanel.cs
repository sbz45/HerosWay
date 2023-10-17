using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissionPanel : MonoBehaviour
{
    [SerializeField] MissionPrefab missionPrefab;
    [SerializeField] GameObject missionContainer;
    [SerializeField] MissionPrefab mainMission;

    public void AddMission(Mission mission)
    {
        if (mission.type == MissionType.mainMission)
        {
            mainMission.UpdateMission(mission);
        }
        else
        {
            Instantiate(missionPrefab.UpdateMission(mission), missionContainer.transform);
        }
    }
    public void FinishMission(Mission mission)
    {
        foreach(var i in missionContainer.GetComponentsInChildren<MissionPrefab>())
        {
            if (i.mission == mission) Destroy(i.gameObject);
        }
    }
}
