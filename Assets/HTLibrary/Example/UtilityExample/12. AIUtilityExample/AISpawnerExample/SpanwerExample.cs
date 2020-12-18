using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using HTLibrary.Utility;
public class SpanwerExample : MonoBehaviour
{
    // Start is called before the first frame update
    IEnumerator Start()
    {
        while(SpawnerManager.Instance.GetNumberOfAI()>0)
        {
            yield return new WaitForSeconds(5.0f);

            SpawnerManager.Instance.RandomSpanwerAI();
        }
  
    }

   
}
