using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
using UnityEngine.UI;
/// <summary>
/// 数学工具的应用案例
/// </summary>
public class MathUtilityExample : MonoBehaviour
{
    public Text ShowText;
    // Start is called before the first frame update
    /// <summary>
    /// 初始化ShowText的内容
    /// </summary>
    void Start()
    {
        if (MathUtility.Percent(20))
        {
            ShowText.text += "You are so lucky...";
        }
        else
        {
            ShowText.text += "You don't lucky...";
        }

        var randomAge = MathUtility.GetRandomValueFrom(new int[] { 1, 2, 3 });
        ShowText.text += "your random age is ::" + randomAge;
    }
}

