using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
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

        if (!Input.GetKeyDown(KeyCode.E)) return;
        if (!canInteract) return;

        if (!isOpen)
        {
            animator.SetTrigger("Open");

        }
        else if (isOpen)
        {
            animator.SetTrigger("Close");
        }

        isOpen = !isOpen;

    }

}
