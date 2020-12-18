using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;

/// <summary>
/// DictionaryUtility 使用案例
/// 将基础物体进行存储
/// </summary>
public class SpawnerDict : MonoBehaviour
{
    Dictionary<PrimitiveType, GameObject> primitiveDict = new Dictionary<PrimitiveType, GameObject>();
    private Color[] cubeColors = { Color.blue, Color.white, Color.gray, Color.green, Color.yellow, Color.cyan };

    /// <summary>
    /// 初始化
    /// </summary>
    private void Start()
    {
        Init();
    }

    /// <summary>
    /// 进行dict统一管理
    /// </summary>
    void Init()
    {
        primitiveDict.Add(PrimitiveType.Cube, LoadPrimitiveObject(PrimitiveType.Cube));
        primitiveDict.Add(PrimitiveType.Capsule, LoadPrimitiveObject(PrimitiveType.Capsule));
        primitiveDict.Add(PrimitiveType.Cylinder, LoadPrimitiveObject(PrimitiveType.Cylinder));
        primitiveDict.Add(PrimitiveType.Sphere, LoadPrimitiveObject(PrimitiveType.Sphere));
    }

    /// <summary>
    /// 通过dict初始化该物体
    /// </summary>
    /// <param name="type"></param>
    /// <returns></returns>
    public GameObject GeneratePrimitiveObject(PrimitiveType type)
    {
        GameObject go= primitiveDict.TryGet<PrimitiveType,GameObject>(type);
        go.SetActive(true);
        return go;
    }

    /// <summary>
    /// 初始化加载基础物体
    /// </summary>
    /// <param name="primitiveType"></param>
    /// <returns></returns>
    GameObject LoadPrimitiveObject(PrimitiveType primitiveType)
    {
       GameObject go= GameObject.CreatePrimitive(primitiveType);
       go.transform.position = new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(0, 5));
       go.GetComponent<Renderer>().material.color = cubeColors[Random.Range(0, cubeColors.Length)];
       go.SetActive(false);
       return go;
    }

    /// <summary>
    /// 隐藏全部字典的物体
    /// </summary>
    public void HideDictObject()
    {
        GeneratePrimitiveObject(PrimitiveType.Cube).SetActive(false);
        GeneratePrimitiveObject(PrimitiveType.Cylinder).SetActive(false);
        GeneratePrimitiveObject(PrimitiveType.Sphere).SetActive(false);
        GeneratePrimitiveObject(PrimitiveType.Capsule).SetActive(false);

        primitiveDict.Clear();

        Init();
    }
}
