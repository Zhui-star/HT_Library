using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using HTLibrary.Framework;
public class AudioManagerExample : MonoBehaviour
{
    public AssetReference coinClip;

    private void Start()
    {
        AudioManager.Instance.PlayMusic(coinClip,true);
    }
}
