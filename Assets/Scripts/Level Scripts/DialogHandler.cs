using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogHandler : MonoBehaviour
{

    [SerializeField] string[] sentences;
    bool canOpenBox;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (canOpenBox && Input.GetKeyDown(KeyCode.E) && !DialogueController.instance.DialogBoxActive())
        {
            DialogueController.instance.ActivateDialog(sentences);
            Debug.Log("Box activated");
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Hero"))
            {
            canOpenBox = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {

            canOpenBox = false;
        }
    }
}
