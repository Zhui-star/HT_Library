using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;

namespace HTLibrary.Utility
{
    public class Wallet :MonoSingleton<Wallet>
    {
        private float coinAmount;

        private void Start()
        {
            this.coinAmount = 100;//TEST 
        }

        /// <summary>
        /// 消耗金钱
        /// </summary>
        /// <param name="coinAmount"></param>
        /// <returns></returns>
        public bool ConsumerCoin(float coinAmount)
        {
            if (this.coinAmount >= coinAmount)
            {
                this.coinAmount -= coinAmount;
                return true;
            }
            return false;
        }

        /// <summary>
        /// 获得金钱
        /// </summary>
        /// <param name="coinAmount"></param>
        public void EarnCoin(float coinAmount)
        {
            this.coinAmount = coinAmount;
        }
    }

}
