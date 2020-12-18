using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using HTLibrary.Utility;

namespace HTLibrary.Framework
{
    public class UIManager :Singleton<UIManager>
    {
        private Transform canvasTransform;
        private Transform CanvasTransform
        {
            get
            {
                if (canvasTransform == null)
                {
                    canvasTransform = GameObject.Find("Canvas").transform;
                }
                return canvasTransform;
            }
        }
        private Dictionary<UIPanelType, string> panelPathDict;//存储所有面板Prefab的路径
        private Dictionary<UIPanelType, BasePanel> panelDict;//保存所有实例化面板的游戏物体身上的BasePanel组件
        private Stack<BasePanel> panelStack;

        public UIManager()
        {
            ParseUIPanelTypeJson();
        }

        /// <summary>
        /// 把某个页面入栈，  把某个页面显示在界面上
        /// </summary>
        public void PushPanel(UIPanelType panelType)
        {
            if (panelStack == null)
                panelStack = new Stack<BasePanel>();

            //判断一下栈里面是否有页面
            if (panelStack.Count > 0)
            {
                BasePanel topPanel = panelStack.Peek();
                topPanel.OnPause();
            }

            BasePanel panel = GetPanel(panelType);
            panel.OnEnter();
            panelStack.Push(panel);
        }
        /// <summary>
        /// 出栈 ，把页面从界面上移除
        /// </summary>
        public void PopPanel()
        {
            if (panelStack == null)
                panelStack = new Stack<BasePanel>();

            if (panelStack.Count <= 0) return;

            //关闭栈顶页面的显示
            BasePanel topPanel = panelStack.Pop();
            topPanel.OnExit();

            if (panelStack.Count <= 0) return;
            BasePanel topPanel2 = panelStack.Peek();
            topPanel2.OnResume();

        }

        /// <summary>
        /// 根据面板类型 得到实例化的面板
        /// </summary>
        /// <returns></returns>
        private BasePanel GetPanel(UIPanelType panelType)
        {
            if (panelDict == null)
            {
                panelDict = new Dictionary<UIPanelType, BasePanel>();
            }

            BasePanel panel = panelDict.TryGet(panelType);

            if (panel == null)
            {
                string path = panelPathDict.TryGet(panelType);
                Debug.Log(path);
                GameObject instPanel = GameObject.Instantiate(Resources.Load(path)) as GameObject;
                instPanel.transform.SetParent(CanvasTransform, false);
                panelDict.Add(panelType, instPanel.GetComponent<BasePanel>());
                return instPanel.GetComponent<BasePanel>();
            }
            else
            {
                return panel;
            }

        }

        [Serializable]
        class UIPanelTypeJson
        {
            public List<UIPanelInfo> infoList = new List<UIPanelInfo>();
        }
        private void ParseUIPanelTypeJson()
        {
            panelPathDict = new Dictionary<UIPanelType, string>();

            TextAsset ta = Resources.Load<TextAsset>("UIPanelType");
            UIPanelTypeJson jsonObject = JsonUtility.FromJson<UIPanelTypeJson>(ta.text);

            foreach (UIPanelInfo info in jsonObject.infoList)
            {
                panelPathDict.Add(info.panelType, info.path);
                Debug.Log(info.panelType);
            }
        }
    }

}
