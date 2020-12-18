using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
public class CubeResuable : ReusableObject
{
    public override void OnSpawn()
    {
        Invoke("DeActiveSelf", 2.0f);
    }

    public override void OnUnSpawn()
    {
        
    }

    void DeActiveSelf()
    {
        PoolManager.Instance.Unspawn(this.gameObject);
    }
}
