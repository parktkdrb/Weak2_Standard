using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestDataSO", menuName = "Quest/Defult/Monster", order = 0)]
public class MonsterQuestSO : QuestDataSO
{
    [Header("Monster Info")]
    public string MonsterName;
    public int KillMonster;
}
