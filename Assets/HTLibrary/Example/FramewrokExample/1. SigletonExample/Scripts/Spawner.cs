using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;

/// <summary>
/// Monon单例模板示例
/// </summary>
public class Spawner : MonoSingleton<Spawner>
{
    /// <summary>
    /// 创造一个Cube
    /// </summary>
    /// <param name="position"></param>
    /// <param name="color"></param>
  public void SpawnCube(Vector3 position, Color color)
    {
        GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);

        go.transform.position = position;
        go.GetComponent<Renderer>().material.color = color;

        Debug.Log("Instance is ::" + Instance.name);
    }
}
