using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace HTLibrary.Utility
{
    public class MovingUI : MonoBehaviour
    {
        public Canvas canvas;

        bool FollowMouse = false;

        protected virtual void SetLocaPosition(Vector3 Position)
        {
            this.transform.localPosition = Position;
        }

        protected  Vector2 MousePositionFromRectTransform()
        {
            Vector2 position;
            RectTransformUtility.ScreenPointToLocalPointInRectangle(canvas.transform as RectTransform, Input.mousePosition, null, out position);
            return position;
        }

        protected virtual void SetFollowMousePosition()
        {
            FollowMouse = true;
        }

        private void Update()
        {
            if(FollowMouse)
            {
              transform.localPosition=   MousePositionFromRectTransform();
            }
        }
    }

}

