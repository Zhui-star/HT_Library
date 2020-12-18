using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using UnityEngine.AddressableAssets;
using HTLibrary.Utility;
public class PoolManagerExample : MonoBehaviour
{
    public Transform parent;
    public AssetReference asset;

    public void SpawnCubeClick()
    {
       GameObject go= PoolManager.Instance.Spawn(asset);
       
       go.transform.SetLocalPosXYZ(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));
    }
}
