using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace HTLibrary.Utility
{
    /// <summary>
    /// 资源工厂接口
    /// 寻找Object
    /// 寻找Lablle
    /// To do : Resources load
    /// To do : AssetBundle
    /// </summary>
    public interface IAssetFactory
    {
        void LoadAddressableObject<T>(AssetReference reference, Action<AsyncOperationHandle<T>> CallBack);
        void LoadAddressableLable<T>(AssetLabelReference label, Action<AsyncOperationHandle<IList<T>>> CallBack);
    }

}
