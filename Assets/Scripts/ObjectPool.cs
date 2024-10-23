using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject prefab;
    public GameObject parent;
    [SerializeField]private List<GameObject> pool = new List<GameObject>();
    public int poolSize = 300;

    private void Awake()
    {
        instance = this;
        parent = gameObject;
    }

    void Start()
    {
        //�̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
        for(int i = 0; i < poolSize; i++)
        {
            GameObject poolIns = Instantiate(prefab);
            Release(poolIns);
        }
            
        
    }
    public GameObject Get()
    {
        // �ٸ� ��ũ��Ʈ���� ������Ʈ Ǯ�� �ִ� ������Ʈ�� �������� ����ϰڴ�?
        // �׷��� ���⼭ Ȱ��ȭ ���Ѽ� ���������.
        // ������Ʈ Ǯ���� ��Ȱ��ȭ�� ������Ʈ�� ã��
        // Ȱ��ȭ ��Ų��.

        GameObject poolGo = null;
        for(int i = 0; i < poolSize; i++)
        {
            if (pool[i].activeSelf == false)
            {
                poolGo = pool[i];
                poolGo.SetActive(true);
                break;
            }
        }
        StartCoroutine(ObjectTimer(poolGo));
        return poolGo;
    }    

    public void Release(GameObject _obj)// 
    {
        // ���ӿ�����Ʈ�� deactive�Ѵ�.
        _obj.SetActive(false);
        pool.Add(_obj);//�̸� poolSize��ŭ ���ӿ�����Ʈ�� �����Ѵ�.
    }

    IEnumerator ObjectTimer(GameObject _obj)
    {
        yield return new WaitForSeconds(3f);

        Release(_obj);

    }


}
