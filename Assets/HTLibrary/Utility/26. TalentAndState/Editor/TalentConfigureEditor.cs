using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using HTLibrary.Utility;
namespace HTLibrary.Editor
{
    public class TalentConfigureEditor
    {
        /// <summary>
        /// 制作一个可编辑天赋容器
        /// </summary>
        [MenuItem("HTLibrary/Make a HT TalentList",false,25)]
       static void MakeTalentConfigure()
        {
            ScriptableObject talentItemConfigure = ScriptableObject.CreateInstance<TalentItemConfigure>();

            string path = "Assets/" + "TalentConfigure.asset";

            AssetDatabase.CreateAsset(talentItemConfigure, path);

            AssetDatabase.SaveAssets();
        }
    }

}
