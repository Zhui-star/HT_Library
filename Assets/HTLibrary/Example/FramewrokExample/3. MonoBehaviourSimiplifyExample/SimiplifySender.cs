using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
/// <summary>
/// MonoBehaviour simplify 框架简单使用
/// 发送事件
/// </summary>
public class SimiplifySender : MonoBehaviourSimplify
{
    protected override void OnBeforeDestroy()
    {
      
    }

    /// <summary>
    /// 发送事件 点击按钮
    /// </summary>
    public void SendClick()
    {
        SendMsg(SimplifyType.Test, null);
    }
}
