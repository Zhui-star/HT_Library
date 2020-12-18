using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTLibrary.Framework
{
    /// <summary>
    /// 抽象继承
    /// </summary>
    public abstract class ReusableObject : MonoBehaviour, IReusable
    {
        public float deactiveTime = 1.5f;

        public abstract void OnSpawn();

        public abstract void OnUnSpawn();
    }

}
