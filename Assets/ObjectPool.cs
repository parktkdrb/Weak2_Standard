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
        pool[poolSize];
        Debug.Log(pool.Count);
    }

    /*public GameObject Get()
    {
        // �����ִ� ���ӿ�����Ʈ�� ã�� active�� ���·� �����ϰ� return �Ѵ�.
    }

    public void Release(GameObject obj)
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
    }*/
}
