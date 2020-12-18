using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
namespace HTLibrary.Utility
{
    /// <summary>
    /// 射线检测工具
    /// 1. 检查2个位置是否有其他障碍物
    /// </summary>
    public class RayCastCheckUtility : Singleton<RayCastCheckUtility>
    {
        public GameObject RasyCastCheckGameObject(Vector3 position_1,Vector3 position_2)
        {
            RaycastHit hitinfo;

            if (Physics.Raycast(position_1,position_1- position_2, out hitinfo))
            {
                if (hitinfo.collider.tag != Tags.Player)
                {
                    return hitinfo.collider.gameObject;
                }
         
            }

            return null;
        }

        public string RayCastCheckFromMouse()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;

            if(Physics.Raycast(ray,out hitInfo))
            {
                return hitInfo.collider.tag;
            }

            return "";
        }

        public Vector3 RayCastPoint()
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hitInfo;
            
            bool isCollider = Physics.Raycast(ray, out hitInfo,1000,LayerMask.GetMask("Ground"));

           if(isCollider)
            {
                return hitInfo.point;
            }
            return Vector3.zero;
            

        }
    }

}
