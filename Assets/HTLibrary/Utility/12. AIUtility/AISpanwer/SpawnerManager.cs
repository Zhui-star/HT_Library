using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using System.Linq;
using System;
namespace HTLibrary.Utility
{
    [Serializable]
    public struct AIS
    {
        public List<GameObject> AIs;
    }
    public class SpawnerManager : MonoSingleton<SpawnerManager>
    {
        private List<Spawner> spawners = new List<Spawner>();

        public List<AIS> AIGroup = new List<AIS>();

        public int numberOfAI;
        private int index;

        private void Awake()
        {
            spawners = FindObjectsOfType<Spawner>().ToList();    
        }

        /// <summary>
        /// 随机孵化AI （随机位置）
        /// </summary>
        public void RandomSpanwerAI()
        {
            if (numberOfAI <= 0) return;

            AIS AIs= AIGroup[index];
            foreach(var tempAI in AIs.AIs)
            {
                int randomSpawner =UnityEngine.Random.Range(0, spawners.Count);
                spawners[randomSpawner].SpawnAI(tempAI);
            }

            index++;
            numberOfAI--;

        }

        /// <summary>
        /// 得到剩余AI波数
        /// </summary>
        /// <returns></returns>
        public int GetNumberOfAI()
        {
            return numberOfAI;
        }
    }

}
