using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;

namespace HTLibrary.Utility
{
    public class EquipPanel :Inventory
    {

        private static EquipPanel _instance;
        public static EquipPanel Instance
        {
            get
            {
                if(_instance==null)
                {
                    _instance = FindObjectOfType<EquipPanel>();
                }

                return _instance;
            }
        }


        public void PutOn(Item item)
        {
            Item exitItem = null;
            foreach (Slot slot in slotList)
            {
                EquipSlot equipmentSlot = (EquipSlot)slot;
                if (equipmentSlot.IsRightItem(item))
                {
                    if (equipmentSlot.transform.childCount > 0)
                    {
                        ItemUI currentItemUI = equipmentSlot.transform.GetChild(0).GetComponent<ItemUI>();
                        exitItem = currentItemUI.Item;
                        currentItemUI.SetItem(item, 1);
                    }
                    else
                    {
                        equipmentSlot.StoreItem(item);
                    }
                    break;
                }
            }
            if (exitItem != null)
                Knapsack.Instance.StoreItem(exitItem);
        }

        public void PutOff(Item item)
        {
            Knapsack.Instance.StoreItem(item);
        }
    }

}
