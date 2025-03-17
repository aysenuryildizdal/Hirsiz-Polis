using UnityEngine;

public class LoaderCallback : MonoBehaviour
{
    // this class is used so that the loading screen is visible for atleast one frame,
    // and only after triggering the loading scene, the loading of target scene can be triggered.
    private bool isFirstUpdate = true;

    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderCallback();
        }
    }
}
