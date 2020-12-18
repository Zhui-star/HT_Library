using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using UnityEngine.UI;

public class ShowText : MonoBehaviour
{
    //注册事件委托 等待被广播
    private void Awake()
    {
        gameObject.SetActive(false);

        EventTypeManager.AddListener<string>(HTEventType.ShowText, Show);
    }

    /// <summary>
    /// 移除事件委托
    /// </summary>
    private void OnDestroy()
    {
        EventTypeManager.RemoveListener<string>(HTEventType.ShowText, Show);
    }

    /// <summary>
    /// 逻辑本身行为
    /// 显示文本
    /// </summary>
    /// <param name="str"></param>
    /// <param name="a"></param>
    private void Show(string str)
    {
        gameObject.SetActive(true);
        GetComponent<Text>().text = str;
    }
}
