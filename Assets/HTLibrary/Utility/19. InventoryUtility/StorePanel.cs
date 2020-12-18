using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;

namespace HTLibrary.Utility
{
    public class StorePanel :Inventory
    {

        private static StorePanel _instance;
        public static StorePanel Instance//单例
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<StorePanel>();
                }

                return _instance;
            }
        }

        /// <summary>
        /// 商店拥有的商品
        /// </summary>
        public int[] itemIDs;

        private void Start()
        {
            InitShop();
        }

        void InitShop()
        {
            foreach (int itemId in itemIDs)
            {
                StoreItem(itemId);
            }
        }

        /// <summary>
        /// 购买物品
        /// </summary>
        /// <param name="item"></param>
        public void BuyItem(Item item)
        {
            bool isSuccess = Wallet.Instance.ConsumerCoin(item.buyPrice);
            if (isSuccess)
            {
                Knapsack.Instance.StoreItem(item);
            }
        }

        public void BuyItemById(int id)
        {
            Item item=   InventoryManager.Instance.GetItemById(id);

            BuyItem(item);
        }

        /// <summary>
        /// 出售物品
        /// </summary>
        /// <param name="item"></param>
        public void SellItem(Item item)
        {
            Wallet.Instance.EarnCoin(item.sellPrice);
            //TODO 背包物品扣除
        }

        public void SellItemById(int id)
        {
            Item item = InventoryManager.Instance.GetItemById(id);
            SellItem(item);
            //TODO 背包物品扣除
        }
    }

}
