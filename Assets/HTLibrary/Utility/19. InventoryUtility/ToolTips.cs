using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace HTLibrary.Utility
{
    /// <summary>
    /// 提示框
    /// </summary>
    public class ToolTips : MovingUI { 


        public Text toolTipText;
        private CanvasGroup canvasGroup;
        public ToolTipType toolTipType;

        public bool IsFollowMouse = false;

        void Start()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void Show(string text)
        {
            toolTipText.text = text;
            canvasGroup.alpha = 1;

            if(IsFollowMouse)
            {
                SetFollowMousePosition();
            }
        }


        public void Hide()
        {
            canvasGroup.alpha = 0;
        }

    }

}
