using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwanPanel : MonoBehaviour
{
    public SpawnerDict spawner;

    /// <summary>
    /// 点击Btn
    /// 进行相应物体创造
    /// </summary>
    /// <param name="type"></param>
    public void CreateCubeClick()
    {
        spawner.GeneratePrimitiveObject(PrimitiveType.Cube);
    }

    public void CreateCylinderClick()
    {
        spawner.GeneratePrimitiveObject(PrimitiveType.Cylinder);
    }

    public void CreateSphereClick()
    {
        spawner.GeneratePrimitiveObject(PrimitiveType.Sphere);
    }
    public void CreateCapusleClick()
    {
        spawner.GeneratePrimitiveObject(PrimitiveType.Capsule);
    }

    /// <summary>
    /// 隐藏基础物体点击
    /// </summary>
    public void HidePrimitiveClick()
    {
        spawner.HideDictObject();
    }
}
