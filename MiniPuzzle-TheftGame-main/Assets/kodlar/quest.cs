using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class quest : MonoBehaviour
{
    public Text objec;

    public string currentobj;
    public string[] objectives;

    private void Start()
    {
        objec.text = objectives[0];
        currentobj = objectives[0];
    }

    private void OnTriggerEnter(Collider coll)
    {
        if(this.gameObject.tag == "Görev1"){
        objec.text = objectives[1]; 
        currentobj = objectives[1];
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "Görev2")
        {
            objec.text = objectives[2];
            currentobj = objectives[2];
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "Görev3")
        {
            objec.text = objectives[3];
            currentobj = objectives[3];
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "Görev4")
        {
            objec.text = objectives[4];
            currentobj = objectives[4];
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "Görev5")
        {
            objec.text = objectives[5];
            currentobj = objectives[5];
            Destroy(gameObject);
        }
    }
}

