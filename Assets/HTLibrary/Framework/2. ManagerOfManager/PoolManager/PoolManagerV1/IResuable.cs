﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace HTLibrary.Framework
{
    /// <summary>
    /// 对象池使用者接口
    /// </summary>
    public interface IReusable
    {
        //取出时候调用
        void OnSpawn();

        //回收调用
        void OnUnSpawn();
    }

}
