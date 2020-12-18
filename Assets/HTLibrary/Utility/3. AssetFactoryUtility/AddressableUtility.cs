using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using System;
using UnityEngine.ResourceManagement.AsyncOperations;
using HTLibrary.Framework;

namespace HTLibrary.Utility
{
    /// <summary>
    /// Addressable 资源管理工具使用
    /// 加载标签
    /// 加载Object
    /// </summary>
    public class AddressableUtility :MonoSingleton<AddressableUtility>, IAssetFactory
    {
        public void LoadAddressableLable<T>(AssetLabelReference label, Action<AsyncOperationHandle<IList<T>>> CallBack)
        {
            Addressables.LoadAssetsAsync<T>(label, null).Completed += CallBack;
        }

        public void  LoadAddressableObject<T>(AssetReference reference, Action<AsyncOperationHandle<T>> CallBack)
        {
             reference.LoadAssetAsync<T>().Completed += CallBack;
        }
    }
}

