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
        if(this.gameObject.tag == "G�rev1"){
        objec.text = objectives[1]; 
        currentobj = objectives[1];
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "G�rev2")
        {
            objec.text = objectives[2];
            currentobj = objectives[2];
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "G�rev3")
        {
            objec.text = objectives[3];
            currentobj = objectives[3];
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "G�rev4")
        {
            objec.text = objectives[4];
            currentobj = objectives[4];
            Destroy(gameObject);
        }
        if (this.gameObject.tag == "G�rev5")
        {
            objec.text = objectives[5];
            currentobj = objectives[5];
            Destroy(gameObject);
        }
    }
}

