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
        //미리 poolSize만큼 게임오브젝트를 생성한다.
        for(int i = 0; i < poolSize; i++)
        {
            GameObject poolIns = Instantiate(prefab);
            Release(poolIns);
        }
            
        
    }
    public GameObject Get()
    {
        // 다른 스크립트에서 오브젝트 풀에 있는 오브젝트를 가져가서 사용하겠다?
        // 그러면 여기서 활성화 시켜서 보내줘야함.
        // 오브젝트 풀에서 비활성화된 오브젝트를 찾고
        // 활성화 시킨다.

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
        // 게임오브젝트를 deactive한다.
        _obj.SetActive(false);
        pool.Add(_obj);//미리 poolSize만큼 게임오브젝트를 생성한다.
    }

    IEnumerator ObjectTimer(GameObject _obj)
    {
        yield return new WaitForSeconds(3f);

        Release(_obj);

    }


}
