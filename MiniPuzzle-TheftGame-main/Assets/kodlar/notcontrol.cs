using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class notcontrol : MonoBehaviour
{
    [SerializeField] private GameObject paperobjekt;
    [SerializeField] private Text notetext;
    [SerializeField] private Text instructionText; 
    public static notcontrol Instance;

    private void Awake()
    {
        Instance = this;
    }
    public void settext(string notestr)
    {
        notetext.text = notestr;
        paperobjekt.SetActive(true);
        instructionText.text = "Oku";
    }
    public void closenot()
    {
        instructionText.text = "";
        paperobjekt.SetActive(false);
    }
}
