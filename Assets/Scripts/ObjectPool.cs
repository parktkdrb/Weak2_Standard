using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject prefab1;
    public GameObject prefab2;
    public GameObject parent;
    [SerializeField] private List<GameObject> pool = new List<GameObject>();
    [SerializeField] private Dictionary<string, List<GameObject>> poolDictionary = new Dictionary<string, List<GameObject>>();
    public int poolSize = 150;

    private void Awake()
    {
        instance = this;
        parent = gameObject;
    }

    void Start()
    {
        GameObject poolIns;
        // 미리 poolSize만큼 게임오브젝트를 생성합니다.
        for (int i = 0; i < poolSize; i++)
        {
            poolIns = Instantiate(prefab1);
            Release(poolIns);
            poolIns = Instantiate(prefab2);
            Release(poolIns);
        }
    }

    public GameObject Get(string str)
    {
        // 해당 키가 딕셔너리에 있는지 확인합니다.
        if (poolDictionary.ContainsKey(str))
        {
            List<GameObject> objectList = poolDictionary[str];

            // 리스트 내에서 비활성화된 오브젝트를 찾습니다.
            foreach (GameObject poolGo in objectList)
            {
                if (!poolGo.activeSelf)
                {
                    poolGo.SetActive(true); // 오브젝트 활성화
                    return poolGo;          // 활성화된 오브젝트 반환
                }
            }
        }

        return null;
    }

    public void Release(GameObject _obj)
    {
        // 게임오브젝트를 비활성화합니다.
        _obj.SetActive(false);
        pool.Add(_obj);

        // 이름을 키로 사용하여 poolDictionary에 오브젝트를 추가합니다.
        string key = _obj.name.Replace("(Clone)", "").Trim();
        if (!poolDictionary.ContainsKey(key))
        {
            poolDictionary[key] = new List<GameObject>();
        }

        poolDictionary[key].Add(_obj);
    }
}
