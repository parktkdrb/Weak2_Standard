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
        //�̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
        for(int i = 0; i < poolSize; i++)
        {
            pool.Add(Instantiate(prefab));
        }
            
        
    }

    public GameObject Get()
    { 
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
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
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        obj.SetActive(false);
    }
}
