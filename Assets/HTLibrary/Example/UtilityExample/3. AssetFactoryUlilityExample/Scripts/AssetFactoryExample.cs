using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement;
using UnityEngine.ResourceManagement.AsyncOperations;
using HTLibrary.Utility;
/// <summary>
/// Addressable 使用案例
/// </summary>
public class AssetFactoryExample : MonoBehaviour
{
    public AssetReference myReference;

    public AssetReference myReference_2;
    /// <summary>
    /// 点击生成Cube
    /// </summary>
    public void GenerateCubeClick()
    {
        AddressableUtility.Instance.LoadAddressableObject<GameObject>(myReference, SetTransform);
    }

    /// <summary>
    /// 生成Cube之后要做的事
    /// </summary>
    /// <param name="obj"></param>
    void  SetTransform(AsyncOperationHandle<GameObject> obj)
    {
        Vector3 position = Random.insideUnitSphere * 5;
        position.Set(position.x, 0, position.z);

        if(obj.IsDone)
        {
            myReference.InstantiateAsync(position,Quaternion.identity);
        }
    }

    /// <summary>
    /// 生成纹理
    /// </summary>
    public void GenerateTextureClick()
    {
        AddressableUtility.Instance.LoadAddressableObject<Texture>(myReference_2, SetTexture);
    }

    /// <summary>
    /// 将纹理赋值在游戏物体上
    /// </summary>
    /// <param name="obj"></param>
    void SetTexture(AsyncOperationHandle<Texture> obj)
    {
        if(obj.IsDone)
        {
            GameObject go= GameObject.CreatePrimitive(PrimitiveType.Cube);
            Vector3 position = Random.insideUnitSphere * 5;
            position.Set(position.x, 0, position.z);
            go.transform.position = position;

            go.GetComponent<Renderer>().material.mainTexture = obj.Result;
        }
    }
}
