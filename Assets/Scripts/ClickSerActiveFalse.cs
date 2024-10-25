using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSerActiveFalse : MonoBehaviour
{
    [SerializeField] private QuestManager _questManager;
    private void Start()
    {
        _questManager = QuestManager.Instance;

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
            string objName = Input.GetKeyDown(KeyCode.A) ? "Square" : "Triangle";
            GameObject obj = ObjectPool.instance.Get($"{objName}");
            StartCoroutine(ObjectTimer(obj));
        }
    }

    IEnumerator ObjectTimer(GameObject _obj)
    {
        yield return new WaitForSeconds(3f);

        ObjectPool.instance.Release(_obj);

    }


}
