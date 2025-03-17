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
        completionButton.gameObject.SetActive(false); // Ba�lang��ta butonu gizle
    }

    public void CheckCompletion()
    {
        // G�rsel tamamlama kontrol� burada ger�ekle�tirilir
        if (IsGameComplete())
        {
            ActivateCompletionButton();
        }
    }

    private bool IsGameComplete()
    {
        // Oyunun tamamlan�p tamamlanmad���n� kontrol eden mant�k burada olabilir
        // �rne�in, t�m par�alar�n do�ru �ekilde yerle�tirildi�ini kontrol edebilirsiniz
        return true; // �rnek olarak her zaman true d�nd�r�yoruz
    }

    private void ActivateCompletionButton()
    {
        completionButton.gameObject.SetActive(true); // Butonu g�r�n�r hale getir
        completionButton.interactable = true; // Butonu etkile�ime a��k hale getir
        completionButton.onClick.AddListener(GoToStartScene); // Butona t�kland���nda ba�lang�� sahnesine git
    }

    private void GoToStartScene()
    {
        SceneManager.LoadScene(0); // 0 indexli sahneye ge�
    }
}
