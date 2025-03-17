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

        // Patrol noktalar�n� bulma
        FindPatrolPoints();
    }

    void FindPatrolPoints()
    {
        // T�m "PatrolPoint" tag'ine sahip nesneleri bulup, patrolPoints dizisine at
        patrolPoints = GameObject.FindGameObjectsWithTag("PatrolPoint").Select(go => go.transform).ToArray();
    }

    void Update()
    {
        if (isPatrolling)
        {
            // Patrol noktalar�nda gezinme
            if (patrolPoints.Length > 0)
            {
                agent.SetDestination(patrolPoints[currentPatrolPointIndex].position);
                mesafe = Vector3.Distance(transform.position, patrolPoints[currentPatrolPointIndex].position);

                // Hedefe ula�t���nda, sonraki patrol noktas�na ge�
                if (mesafe <= 2f)
                {
                    currentPatrolPointIndex++;
                    if (currentPatrolPointIndex >= patrolPoints.Length)
                    {
                        currentPatrolPointIndex = 0;
                    }
                }

                // Mesafe chaseRange'nin alt�na d��t���nde, hedefi takip etmeye ba�la
                if (mesafe <= chaseRange)
                {
                    isPatrolling = false;
                    isChasing = true;
                    targetTransform = GameObject.Find("h�rs�z").transform;
                }
            }
            else
            {
                // patrolPoints dizisi bo�sa, hedefi takip etmeye ba�la
                isPatrolling = false;
                isChasing = true;
                targetTransform = GameObject.Find("h�rs�z").transform;
            }
        }
        else if (isChasing)
        {
            agent.SetDestination(targetTransform.position);
            mesafe = Vector3.Distance(transform.position, targetTransform.position);

            // Mesafe stopChasingRange'nin �zerine ��kt���nda, hedefi kovalamay� b�rak
            if (mesafe >= stopChasingRange)
            {
                isChasing = false;
                isPatrolling = true;
            }
            // Mesafe catchRange'nin alt�na d��t���nde, oyun bitti
            else if (mesafe <= catchRange)
            {
                distanceText.text = "Oyun Bitti!";
                GameOver();
            }
        }

        // Mesafeyi ekrana yazd�r�yoruz
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
        // Oyun bitti panelini g�ster
        gameOverPanel.SetActive(true);
        Time.timeScale = 0f; // Oyun zaman�n� durdur
                             // Fare imle��n�n g�z�kmesini sa�la
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.Confined;
    }

    public void RestartGame()
    {
        // Oyunu yeniden ba�lat
        Time.timeScale = 1f; // Oyun zaman�n� normal h�za getir
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void GoToMainMenu()
    {
        // Ana men�ye d�n
        Time.timeScale = 1f; // Oyun zaman�n� normal h�za getir
        SceneManager.LoadScene(10); // Ana men� sahnesini y�kle
    }
}
