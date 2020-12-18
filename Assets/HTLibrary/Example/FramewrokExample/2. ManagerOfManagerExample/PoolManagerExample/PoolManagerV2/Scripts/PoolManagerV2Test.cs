using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
public class PoolManagerV2Test : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            PoolManagerV2.Instance.GetInst("Bullet");
        }
    }
}
