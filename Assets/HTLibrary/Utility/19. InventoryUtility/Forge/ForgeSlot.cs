using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace HTLibrary.Utility
{
    /// <summary>
    /// 合成材料Slot
    /// </summary>
    public class ForgeSlot : Slot
    {
        public override void OnPointerDown(PointerEventData eventData)
        {
            if(GetItemUI()!=null)
            {
                //Test 将材料放回背包
                if(eventData.button==PointerEventData.InputButton.Left)
                {
                    ForgePanel.instance.PutOff(GetItemUI().Item);
                    DestroyImmediate(transform.GetChild(0).gameObject);
                }
            }
        }
    }
}

