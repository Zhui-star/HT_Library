using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// 单例模板案例
/// 使用单例类创造方块
/// </summary>
public class SpawnBtn : MonoBehaviour
{
    private Color[] cubeColors = { Color.blue, Color.white, Color.gray, Color.green, Color.yellow, Color.cyan };
    /// <summary>
    /// 孵化UI Button点击
    /// </summary>
   public void SpawnClick()
    {
        Spawner.Instance.SpawnCube(new Vector3(Random.Range(-5, 5), Random.Range(-5, 5), Random.Range(-5, 5)), 
            cubeColors[Random.Range(0, cubeColors.Length - 1)]);
    }
}
