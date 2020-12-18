using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTLibrary.Framework
{
    /// <summary>
    /// 游戏入口管理器
    /// 不同阶段执行不同逻辑
    /// production 产品阶段
    /// Test Q&A阶段
    /// Developing 开发阶段
    /// </summary>
    public enum EnviormentMode
    {
        Developing,
        Test,
        Production
    }
    public abstract class MainManager : MonoBehaviour
    {
        public EnviormentMode mode;

        /// <summary>
        /// 根据阶段初始化对应数据
        /// </summary>
        protected virtual void Start()
        {
            switch(mode)
            {
                case EnviormentMode.Developing:
                    LaunchInDevelopingMode();
                    break;
                case EnviormentMode.Test:
                    LaunchInTestMode();
                    break;
                case EnviormentMode.Production:
                    LaunchInProductionMode();
                    break;
            }
        }

        protected abstract void LaunchInDevelopingMode();//开发阶段所需加载的资源
        protected abstract void LaunchInTestMode();//测试阶段所需加载资源
        protected abstract void LaunchInProductionMode();//产品阶段所需要的加载资源
    }

}
