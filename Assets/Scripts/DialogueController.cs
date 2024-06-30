using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class DialogueController : MonoBehaviour
{

    public static DialogueController instance;

    [SerializeField] TextMeshProUGUI dialogText, nameText;

    [SerializeField] GameObject dialogBox, nameBox;

    [SerializeField] string[] lines;

    [SerializeField] int currentLine;

    bool justStarted;

    private void Awake()
    {
        instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        dialogBox.SetActive(false);
        nameBox.SetActive(false);
        
    }

    // Update is called once per frame
    void Update()
    {
        if (dialogBox.activeInHierarchy)
        {
            if (Input.GetButtonUp("Fire1"))
            {
                if (!justStarted)
                {
                    currentLine++;


                    if (currentLine >= lines.Length)
                    {
                        dialogBox.SetActive(false);
                        nameBox.SetActive(false);
                        GameManager.instance.dialogBoxOpen = false;  
                    }
                    else
                    {
                        CheckName();
                        dialogText.text = lines[currentLine];
                    }
                }
                else
                {
                    justStarted = false;
                }
            }

        }


    }

    public void ActivateDialog(string[] linesToUse)
    {
        lines = linesToUse;
        currentLine = 0;
        CheckName();
        dialogText.text = lines[currentLine];
        dialogBox.SetActive(true);
        nameBox.SetActive(true);
        justStarted = true;

        GameManager.instance.dialogBoxOpen = true;
    }
    void CheckName()
    {
        if(lines[currentLine].StartsWith("#"))
        {
            nameText.text = lines[currentLine].Replace("#", "");
            currentLine++;
        }
    }
    public bool DialogBoxActive()
    {
        return dialogBox.activeInHierarchy;
    }
}
