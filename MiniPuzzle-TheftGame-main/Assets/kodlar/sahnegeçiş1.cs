using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneLoader1 : MonoBehaviour
{
    public Text instructionText; // UI'da gösterilecek talimat metni
    private bool isNearDoor = false; // Oyuncunun kapıların yanında olup olmadığını takip eden değişken

    void Start()
    {
    }

    void Update()
    {
        // Eğer oyuncu kapıların yanındaysa ve K tuşuna basarsa
        if (isNearDoor && Input.GetKeyDown(KeyCode.K))
        {
            // Fare imleçünün gözükmesini sağla
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;

            // Sahneyi yükle
            SceneManager.LoadScene(3);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eğer oyuncu kapıların yanına gelirse
        if (other.CompareTag("Player"))
        {
            // Talimat metnini göster
            instructionText.gameObject.SetActive(true);
            instructionText.text = "Kasayı K Tusuna Basarak Kılıdını Kırınız.";
            isNearDoor = true; // Oyuncunun kapıların yanında olduğunu kaydet
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Eğer oyuncu kapıların yanından uzaklaşırsa
        if (other.CompareTag("Player"))
        {
            // Talimat metnini gizle
            instructionText.gameObject.SetActive(false);
            isNearDoor = false; // Oyuncunun kapıların yanından uzaklaştığını kaydet
        }
    }
}
