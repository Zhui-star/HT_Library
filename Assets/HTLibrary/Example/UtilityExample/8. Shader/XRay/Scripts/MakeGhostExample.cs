using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
public class MakeGhostExample : MonoBehaviour
{
    public GhostShadow ghostShadow;


    private Vector3 lastPos = Vector3.zero;

    private void Update()
    {
        //人物有位移才创建残影，不然不创建
        if (lastPos == this.transform.position)
        {
            return;
        }

        lastPos = this.transform.position;

        ghostShadow.MakeGhostShadow();

    }
}
