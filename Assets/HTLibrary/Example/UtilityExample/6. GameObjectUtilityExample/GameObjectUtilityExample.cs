using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
/// <summary>
/// GameObject扩展工具使用案例
/// </summary>
public class GameObjectUtilityExample : MonoBehaviour
{
    public GameObject go;

    /// <summary>
    /// 显示Cube
    /// </summary>
   public void ShowCube()
    {
        go.Show();
    }

    /// <summary>
    /// 隐藏Cube
    /// </summary>
    public void HideCube()
    {
        go.Hide();
    }
}
