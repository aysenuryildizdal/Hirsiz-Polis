using UnityEngine;
using UnityEngine.UIElements;

public class MainMenu : MonoBehaviour
{
    private void Awake() {
        VisualElement root = GetComponent<UIDocument>().rootVisualElement;

        root.Q<Button>("start-btn").clicked += () => StartGame();
        root.Q<Button>("settings-btn").clicked += () => Settings();
        root.Q<Button>("quit-btn").clicked += () => QuitGame();
    }

    private void StartGame() {
        Loader.Load("level-1");
    }

    private void Settings() {
        
    }

    private void QuitGame() {
        
    }
}
