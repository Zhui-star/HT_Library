using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
namespace HTLibrary.Utility
{
    public class CharacterConfigEditor
    {
        [MenuItem("HTLibrary/Chararcter Config")]
        static void CreateItemList()
        {
            CharacterConfig characterConfig = ScriptableObject.CreateInstance<CharacterConfig>();

            string path = "Assets/" + "CharacterConfig.asset";

            AssetDatabase.CreateAsset(characterConfig, path);

            AssetDatabase.SaveAssets();

        }
    }

}
