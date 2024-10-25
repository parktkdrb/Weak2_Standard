using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestDataSO", menuName = "Quest/Defult/Encounter", order = 0)]
public class EncounterSO : QuestDataSO
{
    [Header("Encounter Info")]
    public bool Encounter;
}
