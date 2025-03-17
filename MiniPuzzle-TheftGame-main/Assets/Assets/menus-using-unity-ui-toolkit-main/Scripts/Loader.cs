using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

// video by CodeMonkey: https://www.youtube.com/watch?v=3I5d2rUJ0p

public static class Loader
{
    // loadingMonoBehavior is a dummy class used to start a co-routine,
    // which can only be started by a MonoBehavior extended class
    private class loadingMonoBehavior : MonoBehaviour {}

    private static Action onLoaderCallback;
    private static AsyncOperation loaadingAsyncOperation;

    public static void Load(string scene)
    {
        // set loader callback to target scene, loaderCallBack function will be
        // called from the loading scene
        onLoaderCallback = () => {
            GameObject loadingGameObject = new GameObject("Loading Game Object");
            loadingGameObject.AddComponent<loadingMonoBehavior>().StartCoroutine(LoadSceneAsync(scene));
        };

        // show loading screen
        SceneManager.LoadScene("loading-menu");
    }

    private static IEnumerator LoadSceneAsync(string scene)
    {
        // i don't understand this ***t
        yield return null;
        loaadingAsyncOperation = SceneManager.LoadSceneAsync(scene);
        while (!loaadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if (loaadingAsyncOperation != null)
        {
            return loaadingAsyncOperation.progress;
        }
        else
        {
            return 0.9f;
        }
    }

    public static void LoaderCallback()
    {
        // Triggered after the first update in loading screen, which makes sure loading screen
        // was shown.
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }
}
