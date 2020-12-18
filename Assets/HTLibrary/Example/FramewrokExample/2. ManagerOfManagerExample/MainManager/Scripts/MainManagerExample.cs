using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using HTLibrary.Framework;
public class MainManagerExample : MainManager
{
    public Text showText;
    protected override void LaunchInDevelopingMode()
    {
        showText.text = "当前在开发阶段...\n 伪数据生成...";
    }

    protected override void LaunchInProductionMode()
    {
        showText.text = "当前在产品阶段... \n 加载资源 点击开始游戏...";
    }

    protected override void LaunchInTestMode()
    {
        showText.text = "当前在测试阶段... \n 加载所需要资源 点击开始游戏...";
    }
}
