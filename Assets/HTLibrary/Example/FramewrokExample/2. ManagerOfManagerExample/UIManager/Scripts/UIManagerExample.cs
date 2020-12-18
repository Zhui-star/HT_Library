using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using HTLibrary.Utility;
public class UIManagerExample : MonoBehaviour
{
    private void Start()
    {
        UIManager.Instance.PushPanel(UIPanelType.MainMenue);
    }
}
