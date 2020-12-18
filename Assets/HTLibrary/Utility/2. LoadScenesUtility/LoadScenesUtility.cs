using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HTLibrary.Framework;
using UnityEngine.SceneManagement;
using System;

namespace HTLibrary.Utility
{
    /// <summary>
    /// 加载场景工具
    /// 异步加载
    /// 显示加载进度
    /// 同步加载
    /// </summary>
    public class LoadScenesUtility : MonoSingleton<LoadScenesUtility>
    {
        bool dontDestroy = true;

        /// <summary>
        /// 是否保存该物体？
        /// </summary>
        private void Awake()
        {
            if(dontDestroy)
            {
                DontDestroyOnLoad(this);
            }
        }

        #region 异步加载
        /// <summary>
        /// 异步加载场景接口
        /// </summary>
        /// <param name="index"></param>
        public void LoadingScenesAsync(int index, Action<float> SetLoadingPercentage = null,bool showProcess=true)
        {
            StartCoroutine(StartLoading(index,SetLoadingPercentage,showProcess));
        }

        /// <summary>
        /// 索引为场景名字
        /// </summary>
        /// <param name="index"></param>
        /// <param name="SetLoadingPercentage"></param>
        public void LoadingScenesAsync(string scenesName, Action<float> SetLoadingPercentage = null)
        {
            StartCoroutine(StartLoading(scenesName, SetLoadingPercentage));
        }

        /// <summary>
        /// 异步加载场景逻辑
        /// 显示加载进度条
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IEnumerator StartLoading(int index, Action<float> SetLoadingPercentage = null, bool showProcess = true)
        {
            int displayProgress = 0;
            int toProgress = 0;

            AsyncOperation op = SceneManager.LoadSceneAsync(index);

            if (showProcess)
            {
                op.allowSceneActivation = false;

                while (op.progress < 0.9f)
                {
                    toProgress = (int)op.progress * 100;
                    while (displayProgress < toProgress)
                    {
                        ++displayProgress;
                        if (SetLoadingPercentage != null)
                        {
                            SetLoadingPercentage(displayProgress);
                        }

                        yield return new WaitForEndOfFrame();
                    }
                }

                toProgress = 100;

                while (displayProgress < toProgress)
                {
                    ++displayProgress;
                    if (SetLoadingPercentage != null)
                    {
                        SetLoadingPercentage(displayProgress);
                    }
                    yield return new WaitForEndOfFrame();
                }
            }

            op.allowSceneActivation = true;
        }

        /// <summary>
        /// 索引为场景名
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        IEnumerator StartLoading(string index, Action<float> SetLoadingPercentage = null)
        {
            int displayProgress = 0;
            int toProgress = 0;

            AsyncOperation op = SceneManager.LoadSceneAsync(index);

            op.allowSceneActivation = false;

            while (op.progress < 0.9f)
            {
                toProgress = (int)op.progress * 100;
                while (displayProgress < toProgress)
                {
                    ++displayProgress;
                    if (SetLoadingPercentage != null)
                    {
                        SetLoadingPercentage(displayProgress);
                    }

                    yield return new WaitForEndOfFrame();
                }
            }

            toProgress = 100;

            while (displayProgress < toProgress)
            {
                ++displayProgress;
                if (SetLoadingPercentage != null)
                {
                    SetLoadingPercentage(displayProgress);
                }
                yield return new WaitForEndOfFrame();
            }

            op.allowSceneActivation = true;
        }



        #endregion

        /// <summary>
        /// 同步加载
        /// </summary>
        /// <param name="index"></param>
        public void LoadScenes(int index)
        {
            SceneManager.LoadScene(index);
        }

        /// <summary>
        /// 索引为场景名
        /// </summary>
        /// <param name="scenesName"></param>
        public void LoadScenes(string scenesName)
        {
            SceneManager.LoadScene(scenesName);
        }

    }

}
