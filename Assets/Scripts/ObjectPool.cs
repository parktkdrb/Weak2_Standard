using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public static ObjectPool instance;
    public GameObject prefab;
    public GameObject parent;
    //[SerializeField]private List<GameObject> pool = new List<GameObject>();
    [SerializeField] private Queue<GameObject> pool = new Queue<GameObject>();
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
        /*
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
        */
        if (pool.Count > 0) // 큐에 남아있는 오브젝트가 있으면
        {
            GameObject poolGo = pool.Dequeue(); // 큐에서 하나를 꺼냄
            poolGo.SetActive(true); // 활성화 시킴
            StartCoroutine(ObjectTimer(poolGo)); // 타이머 시작
            return poolGo;
        }
        else
        {
            // 큐가 비었을 때 처리 (필요 시 추가 생성 가능)
            return null;
        }
    }    

    public void Release(GameObject _obj)// 
    {
        /*
        // 게임오브젝트를 deactive한다.
        _obj.SetActive(false);
        pool.Add(_obj);//미리 poolSize만큼 게임오브젝트를 생성한다.
    */

        _obj.SetActive(false);
        pool.Enqueue(_obj); // 다시 큐에 넣음
    }

    IEnumerator ObjectTimer(GameObject _obj)
    {
        yield return new WaitForSeconds(3f);

        Release(_obj);

    }


}
