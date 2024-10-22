using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public GameObject prefab;
    private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    void Start()
    {
        //미리 poolSize만큼 게임오브젝트를 생성한다.
        for(int i = 0; i < poolSize; i++)
        {
            pool.Add(Instantiate(prefab));
        }
            
        
    }

    public GameObject Get()
    { 
        // 꺼져있는 게임오브젝트를 찾아 active한 상태로 변경하고 return 한다.
        for (int i = 0; i < pool.Count; i++)
        {
            prefab = pool[i].gameObject;
            if (prefab.activeSelf == false)
            {
                prefab.SetActive(true);
            }
        }
        return prefab;
    }

    public void Release(GameObject obj)
    {
        // 게임오브젝트를 deactive한다.
        obj.SetActive(false);
    }
}
