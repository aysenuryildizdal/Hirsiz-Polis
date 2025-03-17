using UnityEngine;

public class HideCursor : MonoBehaviour
{
    void Start()
    {
        // Fareyi gizle
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

    }
}
