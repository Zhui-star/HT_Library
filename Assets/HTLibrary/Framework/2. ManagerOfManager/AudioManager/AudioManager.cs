using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Utility;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
namespace HTLibrary.Framework
{
    /// <summary>
    /// 音频管理器
    /// </summary>
    public class AudioManager : MonoSingleton<AudioManager>
    {
        private AudioListener mAudioListener;
        private AudioSource sound;

        /// <summary>
        /// 检查是否有听众
        /// </summary>
        void CheckAudioListener()
        {
            if (!mAudioListener)
            {
                mAudioListener = FindObjectOfType<AudioListener>();
            }

            if (!mAudioListener)
            {
                mAudioListener = gameObject.AddComponent<AudioListener>();
            }
        }

        /// <summary>
        /// 播放音效
        /// </summary>
        /// <param name="audioClip"></param>
        public void PlaySound(AssetReference audioClip)
        {
            CheckAudioListener();

            if (sound == null)
            {
                sound = gameObject.AddComponent<AudioSource>();
            }

            AddressableUtility.Instance.LoadAddressableObject<AudioClip>(audioClip, OnFinishLoadedSound);
            

        
        }

        /// <summary>
        /// 完成音效加载
        /// </summary>
        /// <param name="obj"></param>
        void OnFinishLoadedSound(AsyncOperationHandle<AudioClip> obj)
        {
            sound.clip = obj.Result;
            sound.Play();
        }


        private AudioSource mMusicSource;

        /// <summary>
        /// 播放音频
        /// </summary>
        /// <param name="audioClip"></param>
        /// <param name="loop"></param>
        public void PlayMusic(AssetReference audioClip, bool loop)
        {
            CheckAudioListener();

            if (!mMusicSource)
            {
                mMusicSource = gameObject.AddComponent<AudioSource>();
            }

            AddressableUtility.Instance.LoadAddressableObject<AudioClip>(audioClip, OnFinishedLoadedMusic);
            mMusicSource.loop = loop;

        }

        /// <summary>
        /// 完成音频加载
        /// </summary>
        /// <param name="obj"></param>
        void OnFinishedLoadedMusic(AsyncOperationHandle<AudioClip> obj)
        {
            mMusicSource.clip = obj.Result;    
            mMusicSource.Play();
        }

        /// <summary>
        /// 停止播放音频
        /// </summary>
        public void StopMusic()
        {
            mMusicSource.Stop();
        }

        /// <summary>
        /// 暂停播方音频
        /// </summary>
        public void PauseMusic()
        {
            mMusicSource.Pause();
        }

        /// <summary>
        /// 启动音频播放
        /// </summary>
        public void ResumeMusic()
        {
            mMusicSource.UnPause();
        }

        /// <summary>
        /// 静音音频
        /// </summary>
        public void MusicOff()
        {
            mMusicSource.Pause();
            mMusicSource.mute = true;
        }

        /// <summary>
        /// 静音音效
        /// </summary>
        public void SoundOff()
        {
            var soundSources = GetComponents<AudioSource>();

            foreach (var soundSource in soundSources)
            {
                if (soundSource != mMusicSource)
                {
                    soundSource.Pause();
                    soundSource.mute = true;
                }
            }
        }

        /// <summary>
        /// 音频开启非静音
        /// </summary>
        public void MusicOn()
        {
            mMusicSource.UnPause();
            mMusicSource.mute = false;
        }

        /// <summary>
        /// 开启音效
        /// </summary>
        public void SoundOn()
        {
            var soundSources = GetComponents<AudioSource>();

            foreach (var soundSource in soundSources)
            {
                if (soundSource != mMusicSource)
                {
                    soundSource.UnPause();
                    soundSource.mute = false;
                }
            }
        }
    }

}
