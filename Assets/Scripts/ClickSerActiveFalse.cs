using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickSerActiveFalse : MonoBehaviour
{

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ObjectPool.instance.Get();
        }
    }

    
}
