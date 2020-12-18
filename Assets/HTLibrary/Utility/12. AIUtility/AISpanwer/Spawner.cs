using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HTLibrary.Utility
{
    /// <summary>
    /// 物体孵化器
    /// </summary>
    public class Spawner : MonoBehaviour
    {
        public Transform parent;
        [Header("是否使用对象池")]
        public bool IsUseObjectPool = false;

        /// <summary>
        /// 孵化物体
        /// </summary>
        /// <param name="go"></param>
       public void SpawnAI(GameObject go)
        { 
            if(IsUseObjectPool)
            {
                //TODO
            }
            else
            {
                GameObject tempGo = GameObject.Instantiate(go, parent);
                tempGo.transform.position = this.transform.position;
                tempGo.transform.rotation = transform.rotation;

            }
        }
    }

}
