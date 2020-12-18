using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;

/// <summary>
/// 时间条回合制使用UI
/// </summary>
public class MenuePanel_ActionBar : MonoBehaviour
{
    public void OnEndRoundClick()
    {
        ActionBarRoundManager.Instance.GetRoundChracterByType(ActionBarRoundManager.Instance.GetPlayerType()).actionBar.CanExcute = false;
    }
}
