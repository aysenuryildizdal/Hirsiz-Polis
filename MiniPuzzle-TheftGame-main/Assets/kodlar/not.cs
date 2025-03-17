using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class not : MonoBehaviour
{
    [SerializeField] [TextArea]private string notestring;
    public string getnote()
    {
        return notestring;
    }
}
