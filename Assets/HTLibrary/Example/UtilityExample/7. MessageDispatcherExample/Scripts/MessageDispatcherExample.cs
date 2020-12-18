using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
using UnityEngine.UI;
public enum MessageType
{
    Hello,
    Fuck
}
public class MessageDispatcherExample : MonoBehaviour
{
    public Text showText;
    private void Start()
    {
        MessageDispatcherManagerUtility.Instance.GetDispatcher(MessageDispatcherType.ShowText).Register(MessageType.Hello, Hello);
        MessageDispatcherManagerUtility.Instance.GetDispatcher(MessageDispatcherType.ShowText). Register(MessageType.Fuck, Fuck);
    }

    void Hello(object data)
    {
        showText.text = data as string;
    }

    void Fuck(object data)
    {
        showText.text = data as string;
    }
}
