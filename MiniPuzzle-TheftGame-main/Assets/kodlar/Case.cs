using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Case : MonoBehaviour
{
    public bool canInteract;
    public bool isOpen;
    Animator animator;
    public string previousScene;
    void Start()
    {
        animator = GetComponent<Animator>();


    }

    private void OnTriggerStay(Collider othedar)
    {
        if (!othedar.CompareTag("Player")) return;
        canInteract = true;
    }
    private void OnTriggerExit(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        canInteract = false;
    }



    void Update()
    {
        if (!Input.GetKeyDown(KeyCode.K)) return;
        if (!canInteract) return;

        if (!isOpen)
        {
            animator.SetTrigger("Open");

        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
    }
}

