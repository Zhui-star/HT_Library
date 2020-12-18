using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;

namespace HTLibrary.Utility
{
    public class Knapsack :Inventory
    {
        #region 单例模式
        private static Knapsack _instance;
        public static Knapsack Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<Knapsack>();
                }
                return _instance;
            }
        }
        #endregion


    }

}
