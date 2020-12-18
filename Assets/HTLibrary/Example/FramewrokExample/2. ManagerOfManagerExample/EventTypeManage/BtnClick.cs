using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTLibrary.Framework;
/// EventTypeManager 使用案例
public class BtnClick : MonoBehaviour
{
    /// <summary>
    /// 对ShowType事件进行广播
    /// </summary>
    private void Start()
    {
        GetComponent<Button>().onClick.AddListener(() =>
        {
            EventTypeManager.Broadcast(HTEventType.ShowText, "事件广播高度解耦");
        });
    }
}

