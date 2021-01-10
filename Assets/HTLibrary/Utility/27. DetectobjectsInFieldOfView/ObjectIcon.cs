using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;

namespace HTLibrary.Utility
{
    /// <summary>
    /// 物体身上Icon
    /// </summary>
    public class ObjectIcon : MonoBehaviour
    {
        private Transform objectIcon;
        private Transform playerTransform;
        public float Offset = 200;
        private void Start()
        {
            objectIcon = UIIndicatorPanel.Instance.GetObjectIconTrs();
            playerTransform = GameObject.FindGameObjectWithTag(Tags.Player).transform;
        }

        private void FixedUpdate()
        {
            if(!IsInView())
            {
                IconUpdate();
            }
            else
            {
                ImplementInView();
            }
        }

        private void OnDisbale()
        {
            ImplementInView();
        }

        void ImplementInView()
        {
            objectIcon.gameObject.SetActive(false);
        }

        bool IsInView()
        {
            Transform camTransform = Camera.main.transform;
            Vector2 viewPos = Camera.main.WorldToViewportPoint(transform.position);
            Vector3 dir = (transform.position - camTransform.position).normalized;
            float dot = Vector3.Dot(camTransform.forward, dir);
            if (dot > 0 && viewPos.x >= 0 && viewPos.x <= 1 && viewPos.y >= 0 && viewPos.y <= 1)
            {
                Debug.Log("<color=yellow> 在视野内 </color>");
                return true;
            }
            else
            {
                Debug.Log("<color=yellow> 不在视野</color>");
                return false;
            }
        }

        void IconUpdate()
        {
            objectIcon.gameObject.SetActive(true);
            Vector3 indicatorPoint = (transform.position - playerTransform.position).normalized + playerTransform.position;
            Vector3 indicatorScnPoint = Camera.main.WorldToScreenPoint(indicatorPoint);
            Vector3 playerPos = Camera.main.WorldToScreenPoint(playerTransform.position);

            Vector2 indicatorUIPoint;
            Vector2 playerUIPos;
            RectTransformUtility.ScreenPointToLocalPointInRectangle((UIIndicatorPanel.Instance.transform as RectTransform), 
                indicatorScnPoint, null, out indicatorUIPoint);
            RectTransformUtility.ScreenPointToLocalPointInRectangle((UIIndicatorPanel.Instance.transform as RectTransform)
                , playerPos, null, out playerUIPos);


            Vector2 indicatorPos = playerUIPos + (indicatorUIPoint - playerUIPos).normalized*Offset;

            objectIcon.localPosition= new Vector3(indicatorPos.x, indicatorPos.y, 0);

            UILookAt(objectIcon, indicatorUIPoint - playerUIPos, Vector3.up);


        }

        void UILookAt(Transform transform, Vector3 dir, Vector3 lookAxis)
        {
            Quaternion q = Quaternion.identity;
            q.SetFromToRotation(lookAxis, dir);
            transform.rotation = q;
        }

    }

}
