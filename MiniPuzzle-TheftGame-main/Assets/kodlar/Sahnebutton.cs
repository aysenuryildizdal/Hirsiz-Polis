using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Sahnebutton : MonoBehaviour
{
    [SerializeField] private GameObject gameBoard;
    [SerializeField] private Button completionButton;

    private void Start()
    {
        completionButton.gameObject.SetActive(false); // Baþlangýçta butonu gizle
    }

    public void CheckCompletion()
    {
        // Görsel tamamlama kontrolü burada gerçekleþtirilir
        if (IsGameComplete())
        {
            ActivateCompletionButton();
        }
    }

    private bool IsGameComplete()
    {
        // Oyunun tamamlanýp tamamlanmadýðýný kontrol eden mantýk burada olabilir
        // Örneðin, tüm parçalarýn doðru þekilde yerleþtirildiðini kontrol edebilirsiniz
        return true; // Örnek olarak her zaman true döndürüyoruz
    }

    private void ActivateCompletionButton()
    {
        completionButton.gameObject.SetActive(true); // Butonu görünür hale getir
        completionButton.interactable = true; // Butonu etkileþime açýk hale getir
        completionButton.onClick.AddListener(GoToStartScene); // Butona týklandýðýnda baþlangýç sahnesine git
    }

    private void GoToStartScene()
    {
        SceneManager.LoadScene(0); // 0 indexli sahneye geç
    }
}
