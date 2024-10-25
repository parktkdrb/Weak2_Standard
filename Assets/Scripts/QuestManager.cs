using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour
{
    //구현사항1
    private static QuestManager _instance;

    public static QuestManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new GameObject("QuestManager").AddComponent<QuestManager>();
            }
            return _instance;
        }
    }
    [SerializeField] public List<QuestDataSO> data = new List<QuestDataSO>();

    private void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < data.Count; i++)
        {
            Debug.Log($"Quest{i} : {data[i].QuestName} (최소레벨{data[i].QuestRequiredLevel})");
            if (data[i] is EncounterSO encounterQuest)
            {
                Debug.Log($"{data[i].QuestDetail}");
            }
            else if (data[i] is MonsterQuestSO monsterQuest)
            {
                Debug.Log($"{monsterQuest.MonsterName}를 {monsterQuest.KillMonster} 소탕");
            }
            
        }
    }

}
