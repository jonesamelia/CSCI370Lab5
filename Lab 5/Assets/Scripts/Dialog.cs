using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialog : MonoBehaviour
{
    
    public string text;

    public void OnTriggerEnter(Collider collider) {
        print("Entered..");
        if (collider.gameObject.CompareTag("Player")) {
            GameManager.Instance.DialogShow(text);
        }
    }
    public void OnTriggerExit(Collider collider) {
        if (collider.gameObject.CompareTag("Player")) {
            GameManager.Instance.DialogHide();
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
