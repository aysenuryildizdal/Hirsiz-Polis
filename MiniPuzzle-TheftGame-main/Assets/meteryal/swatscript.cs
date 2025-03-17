using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class swatscript : MonoBehaviour
{
    private Animator swatanim;
    private NavMeshAgent agent;
    public float mesafe;
    public Text distanceText;
    public GameObject gameOverPanel;
    public Button restartButton;
    public Button mainMenuButton;

    private Transform[] patrolPoints;
    private int currentPatrolPointIndex = 0;
    private bool isPatrolling = true;
    private Transform targetTransform;
    private bool isChasing = false;
    private float chaseRange = 10f;
    private float stopChasingRange = 20f;
    private float catchRange = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        swatanim = GetComponent<Animator>();
        gameOverPanel.SetActive(false);
        restartButton.onClick.AddListener(RestartGame);
        mainMenuButton.onClick.AddListener(GoToMainMenu);

        // Patrol noktalarýný bulma
        FindPatrolPoints();
    }

    void FindPatrolPoints()
    {
        // Tüm "PatrolPoint" tag'ine sahip nesneleri bulup, patrolPoints dizisine at
        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint").Select(go => go.transform).ToArray();
    }

    void Update()
    {
        if (isPatrolling)
        {
            // Patrol noktalarýnda gezinme
            if (patrolPoints.Length > 0)
            {
                agent.SetDestination(patrolPoints[currentPatrolPointIndex].position);
                mesafe = Vector3.Distance(transform.position, patrolPoints[currentPatrolPointIndex].position);

                // Hedefe ulaþtýðýnda, sonraki patrol noktasýna geç
                if (mesafe <= 2f)
                {
                    currentPatrolPointIndex++;
                    if (currentPatrolPointIndex >= patrolPoints.Length)
                    {
                        currentPatrolPointIndex = 0;
                    }
                }

                // Mesafe chaseRange'nin altýna düþtüðünde, hedefi takip etmeye baþla
                if (mesafe <= chaseRange)
                {
                    isPatrolling = false;
                    isChasing = true;
                    targetTransform = GameObject.Find("hýrsýz").transform;
                }
            }
            else
            {
                // patrolPoints dizisi boþsa, hedefi takip etmeye baþla
                isPatrolling = false;
                isChasing = true;
                targetTransform = GameObject.Find("hýrsýz").transform;
            }
        }
        else if (isChasing)
        {
            agent.SetDestination(targetTransform.position);
            mesafe = Vector3.Distance(transform.position, targetTransform.position);

            // Mesafe stopChasingRange'nin üzerine çýktýðýnda, hedefi kovalamayý býrak
            if (mesafe >= stopChasingRange)
            {
                isChasing = false;
                isPatrolling = true;
            }
            // Mesafe catchRange'nin altýna düþtüðünde, oyun bitti
            else if (mesafe <= catchRange)
            {
                distanceText.text = "Oyun Bitti!";
                GameOver();
            }
        }

        // Mesafeyi ekrana yazdýrýyoruz
        distanceText.text = "Mesafe: " + mesafe.ToString("F2") + " metre";

        if (agent.velocity == Vector3.zero)
        {
            swatanim.SetBool("ismoving", false);
        }
        else
        {
            swatanim.SetBool("ismoving", true);
        }
    }

    void GameOver()
    {
        // Oyun bitti panelini göster
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Oyun zamanýný durdur
                             // Fare imleçünün gözükmesini saðla
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RestartGame()
    {
        // Oyunu yeniden baþlat
        Time.timeScale = 1f; // Oyun zamanýný normal hýza getir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        // Ana menüye dön
        Time.timeScale = 1f; // Oyun zamanýný normal hýza getir
        SceneManager.LoadScene(10); // Ana menü sahnesini yükle
    }
}
