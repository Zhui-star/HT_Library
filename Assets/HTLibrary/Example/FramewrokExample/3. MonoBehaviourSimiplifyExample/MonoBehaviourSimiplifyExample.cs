using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using UnityEngine.UI;
/// <summary>
/// MonoBehaviour simplify 框架简单使用
/// </summary>
public class MonoBehaviourSimiplifyExample : MonoBehaviourSimplify
{
    public Text showText;
    protected override void OnBeforeDestroy()
    {
        Debug.Log("OnBeforeDestroy");
    }

    /// <summary>
    /// 注册事件
    /// </summary>
    private void OnEnable()
    {
        RegisterMsg(SimplifyType.Test, Test);
    }

    /// <summary>
    /// 写在事件
    /// </summary>
    private void OnDisable()
    {
        UnRegisterMsg(SimplifyType.Test, null);
    }

    /// <summary>
    /// 显示文本内容
    /// </summary>
    /// <param name="data"></param>
    public void Test(object data)
    {
        showText.text = "Have people call me ?";
    }


    /// <summary>
    /// 延时功能 测试
    /// </summary>
    private void Start()
    {
        Delay(5.0f, OnFinished);
    }

    /// <summary>
    /// 延时完 回调函数
    /// </summary>
    void OnFinished()
    {
        showText.text = "Nice I am change...";
    }



}
