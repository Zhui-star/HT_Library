using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using HTLibrary.Utility;
using UnityEngine.SceneManagement;
namespace HTLibrary.Framework
{
    /// <summary>
    /// 基于Addressable 对象池管理器
    /// </summary>
    public class PoolManager : MonoSingleton<PoolManager>
    {

        Dictionary<string , SubPool> m_pools = new Dictionary<string, SubPool>();

        //取出物体
        public GameObject Spawn(AssetReference assetReference)
        {
            SubPool pool;
            if(m_pools.Count>0)
            {
                string[] splitStrs = assetReference.ToString().Split(']');
                pool = m_pools.TryGet<string, SubPool>(splitStrs[0]);
                GameObject go = pool.Spawn();

                return go;
            }
            else
            {
                return null;
            }
        }

        //回收物体
        public void Unspawn(GameObject go)
        {
            SubPool pool = null;
            foreach (var p in m_pools.Values)
            {
                if (p.Contain(go))
                {
                    pool = p;
                    break;
                }
            }
            pool.UnSpawn(go);
        }

        //回收所有
        public void UnspawnAll()
        {
            foreach (var p in m_pools.Values)
            {
                p.UnspawnAll();
            }
        }

        //清除所有
        public void Clear()
        {
            m_pools.Clear();
        }

        #region 初始化对象池
        AssetReference assetReference = null;

        void RegieterNew(AssetReference asset)
        {
            assetReference = asset;

            AddressableUtility.Instance.LoadAddressableObject<GameObject>(asset, OnFinishLoaded);
        }

        void OnFinishLoaded(AsyncOperationHandle<GameObject> finish)
        {
            SubPool pool = new SubPool(this.transform, finish.Result);

            string[] splitStrs = assetReference.ToString().Split(']');

            if (!m_pools.ContainsKey(splitStrs[0]))
            {
                m_pools.Add(splitStrs[0], pool);
                isFinished = true;
                index++;
            }
        }


        public List<AssetReference> objectsPool = new List<AssetReference>();
        bool isFinished = true;
        private int index = 0;
        public int Index
        {
            get
            {
                return index;
            }
        }

        public bool  DoesAllLoaded()
        {
            return Index == objectsPool.Count - 1;
        }

        public IEnumerator Start()
        {
            foreach (var temp in objectsPool)
            {
                yield return new WaitUntil(() => isFinished);
                RegieterNew(temp);
                isFinished = false;
            }
        }
        #endregion
    }
    /*
     * 1. index=0
     * 2. list[0]=cube list[0]=sphere
     * 2. add(temp)
     * 3. list[index]=asset
     * 
     */

}
