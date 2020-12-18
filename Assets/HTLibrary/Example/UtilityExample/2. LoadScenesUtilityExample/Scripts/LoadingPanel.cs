using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
using UnityEngine.UI;
/// <summary>
/// 场景加载工具使用示例
/// </summary>
public class LoadingPanel : MonoBehaviour
{
    public Slider progressSlider;

    /// <summary>
    /// 开始加载场景
    /// </summary>
    private void Start()
    {
        if(progressSlider==null)
        {
            LoadScenesUtility.Instance.LoadingScenesAsync(0);
            return;
        }
        LoadScenesUtility.Instance.LoadingScenesAsync(1, SetLoadingPercentage);
    }

    /// <summary>
    /// 设置加载进度
    /// </summary>
    /// <param name="percentage"></param>
    void  SetLoadingPercentage(float percentage)
    {
        progressSlider.value = percentage / 100;
    }
}
