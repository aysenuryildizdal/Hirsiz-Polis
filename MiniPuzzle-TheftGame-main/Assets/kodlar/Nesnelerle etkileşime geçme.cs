using UnityEngine;
using UnityEngine.UI;

public class ClickAndDestroy : MonoBehaviour
{
    public Text scoreText;
    public Text clickDurationText;
    private int score = 0;
    private float clickStartTime = 0f;
    private float clickDuration = 0.5f; // 2 saniye basılı tutma süresi
    private bool isClickingObject = false;

    void Start()
    {
        // Text bileşeninin başlangıçta gizli olmasını sağla
        clickDurationText.gameObject.SetActive(false);
        UpdateScoreText();
    }

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            clickStartTime = Time.time;
            isClickingObject = false; // Tıklama başladı, ancak henüz nesne üzerinde değil

            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
            {
                if (hit.transform.CompareTag("para"))
                {
                    isClickingObject = true; // Nesne üzerinde tıklama yapıldı
                    // Text bileşenini görünür hale getir
                    clickDurationText.gameObject.SetActive(true);
                }
            }
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            float timePassed = Time.time - clickStartTime;
            if (timePassed >= clickDuration && isClickingObject)
            {
                RaycastHit hit;
                if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit))
                {
                    if (hit.transform.CompareTag("para"))
                    {
                        Destroy(hit.transform.gameObject);
                        IncreaseScore();
                    }
                }
            }
            clickStartTime = 0f; // Tıklama başlangıcı sıfırlandı
            isClickingObject = false;
            // Text bileşenini gizle
            clickDurationText.gameObject.SetActive(false);
        }

        // Ekrana kalan süreyi yazdır
        float timeRemaining = clickDuration - (Time.time - clickStartTime);
        if (timeRemaining > 0 && isClickingObject)
        {
            clickDurationText.text = "Toplama Süresi " + timeRemaining.ToString("F2") + " saniye";
        }
        else
        {
            clickDurationText.text = "";
        }
    }

    void IncreaseScore()
    {
        score++;
        UpdateScoreText();
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }
}
