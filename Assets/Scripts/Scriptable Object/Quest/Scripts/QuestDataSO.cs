using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "QuestDataSO", menuName = "Quest/Defult", order = 0)]
public class QuestDataSO : ScriptableObject
{
    [Header("Quest Info")]
    public string QuestName; //퀘스트의 이름
    public string QuestDetail; //퀘스트의 이름
    public int QuestRequiredLevel; //퀘스트의 최소레벨
    public int QuestNPC; // 퀘스트를 주는 NPC의 id(int)
    public int QuestPrerequisites; //선행 퀘스트의 id들의 리스트

}
