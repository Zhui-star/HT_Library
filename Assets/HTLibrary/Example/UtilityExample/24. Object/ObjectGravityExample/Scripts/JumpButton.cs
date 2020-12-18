using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
public class JumpButton : MonoBehaviour
{
    public ObjectGravity gravity;
    public float jumpValue = 10;
    public void JumpClick()
    {
        gravity.SetJumpValue(jumpValue);
    }
}
