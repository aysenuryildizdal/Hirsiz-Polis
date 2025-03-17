using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class kapı2 : MonoBehaviour
{
    public Text instructionText; // UI'da gösterilecek talimat metni
    private bool isNearDoor = false; // Oyuncunun kapıların yanında olup olmadığını takip eden değişken
    private int currentDoorIndex = 0; // Şu anki kapının indexi

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

            // Kapının indexine göre sahneyi yükle
            SceneManager.LoadScene(8);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Eğer oyuncu kapıların yanına gelirse
        if (other.CompareTag("Player"))
        {
            // Kapının indexini bul
            int doorIndex = System.Array.IndexOf(GameObject.FindGameObjectsWithTag("Door"), other.gameObject);

            // Talimat metnini göster
            instructionText.gameObject.SetActive(true);
            instructionText.text = $"Kapı Kılıtlı, K Tusuna Basarak Kırın.";
            isNearDoor = true;
            currentDoorIndex = doorIndex;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Eğer oyuncu kapıların yanından uzaklaşırsa
        if (other.CompareTag("Player"))
        {
            // Talimat metnini gizle
            instructionText.gameObject.SetActive(false);
            isNearDoor = false;
        }
    }
}
