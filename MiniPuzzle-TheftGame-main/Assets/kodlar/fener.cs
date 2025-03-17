using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elfeneri : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private bool ýþýk;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            ýþýk = !ýþýk;
            flashlight.SetActive(ýþýk);
        }
    }
}
