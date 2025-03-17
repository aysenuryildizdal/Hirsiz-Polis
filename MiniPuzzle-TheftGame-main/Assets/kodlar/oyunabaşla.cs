using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class oyunabaşla : MonoBehaviour
{
    public void OnDoneClicked()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
    public void ögretiçi()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        UnityEngine.SceneManagement.SceneManager.LoadScene(7);
    }
}
