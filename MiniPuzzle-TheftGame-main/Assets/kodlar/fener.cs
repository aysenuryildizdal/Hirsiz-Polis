using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elfeneri : MonoBehaviour
{
    [SerializeField] GameObject flashlight;
    private bool ���k;

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.F))
        {
            ���k = !���k;
            flashlight.SetActive(���k);
        }
    }
}
