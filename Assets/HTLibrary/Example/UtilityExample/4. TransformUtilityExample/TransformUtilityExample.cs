using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
/// <summary>
/// Transform拓展工具使用案例
/// </summary>
public class TransformUtilityExample : MonoBehaviour
{
  /// <summary>
  /// 生成Cube
  /// 设置位置
  /// 生成子物体 父物体
  /// </summary>
  public void GenerateCubeClick()
    {
        GameObject gameObject = GameObject.CreatePrimitive(PrimitiveType.Cube);

        gameObject.transform.SetLocalPosXYZ(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5));

        var parentTrans = new GameObject("ParentTransform").transform;
        var childTrans = new GameObject("ChildTransform").transform;

        parentTrans.AddChild(childTrans);
    }
}
