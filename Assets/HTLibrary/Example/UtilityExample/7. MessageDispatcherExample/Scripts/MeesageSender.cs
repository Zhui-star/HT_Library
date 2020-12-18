using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;

/// <summary>
/// MessageDispatcherUtility使用示例
/// 发送不同的消息
/// </summary>
public class MeesageSender : MonoBehaviour
{
    /// <summary>
    /// 发送关于Hello的消息
    /// </summary>
   public void SendHelloClick()
    {
        MessageDispatcherManagerUtility.Instance.GetDispatcher(MessageDispatcherType.ShowText).Send(MessageType.Hello,"Hello...");
    }

    /// <summary>
    /// 发送关于Fuck的消息
    /// </summary>
    public void SendFuckClick()
    {
        MessageDispatcherManagerUtility.Instance.GetDispatcher(MessageDispatcherType.ShowText).Send(MessageType.Fuck, "Fuck...");
    }
}
