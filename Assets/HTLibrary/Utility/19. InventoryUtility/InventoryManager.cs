using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
namespace HTLibrary.Utility
{
    /// <summary>
    /// 背包系统管理
    /// </summary>
    public class InventoryManager :MonoSingleton<InventoryManager>
    {
        public ItemList itemList;

        private ItemUI pickedItem;//鼠标选中的物体

        private Canvas canvas;

        public ItemUI PickedItem
        {
            get
            {
                return pickedItem;
            }

            set
            {
                pickedItem = value;
            }
        }

        public Item itemPickedItem { get; set; }
        public Slot PickedSlot { set; get; }

        public Item GetItemById(int id)
        {
            foreach (Item item in itemList.itemList)
            {
                if (item.itemID == id)
                {
                    return item;
                }
            }
            return null;
        }

        //捡起物品槽指定数量的物品
        public void PickupItem(Item item)
        {
            itemPickedItem = item;
        }

        /// <summary>
        /// 从手上拿掉一个物品放在物品槽里面
        /// </summary>
        public void RemoveItem(int amount = 1)
        {
            PickedItem.ReduceAmount(amount);
            if (PickedItem.Amount <= 0)
            {
                PickedItem.Hide();
            }
        }

  

    }

}
