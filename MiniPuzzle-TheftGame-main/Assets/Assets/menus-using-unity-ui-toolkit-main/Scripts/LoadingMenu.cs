using UnityEngine;
using UnityEngine.UIElements;

public class LoadingMenu : MonoBehaviour
{
    private ProgressBar progressBar;
    
    private void Awake() {
        progressBar = GetComponent<UIDocument>().rootVisualElement.Q<ProgressBar>("loading-progress-bar");    
    }

    void Update()
    {
        progressBar.value = Loader.GetLoadingProgress();
    }
}
