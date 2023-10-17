using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Mission", menuName = "Mission", order = 0)]
public class Mission :ScriptableObject
{

    [SerializeField] public string MissionName;
    [SerializeField] public string MissionDescription;

    [SerializeField] string FromWhom;
    [SerializeField] public MissionType type;
    [SerializeField] public List<Item> rewards=new();
}
public enum MissionType
{
    mainMission,
    sideQuest
}
