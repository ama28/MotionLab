using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using Ink.Runtime;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    [Header("Params")]
    [SerializeField] private float typingSpeed = 0.03f;
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;
    [SerializeField] private TextMeshProUGUI dialogueText2;
    //[SerializeField] private GameObject continueIcon;
    private Story currentStory;
    public bool dialogueIsPlaying;
    private Coroutine displayLineCoroutine;
    private bool canContinueToNextLine = false;
    public bool scrollingText;
    public bool textEnd;
        
    // Singleton property
    public static DialogueManager Instance { get; private set; }

    public static DialogueManager GetInstance()
    {
        return Instance;
    }
    private void Awake()
    {
        textEnd = false;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
        }

        Instance = this;
    }

    private void Update()
    {
        //return right away if dialogue is not playing
        if (!dialogueIsPlaying)
        {
            return;
        }

        // handle continuing to the next line in the dialogue when submit is pressed
        if (Input.GetMouseButtonDown(0) )
        {
            if (!canContinueToNextLine)
            {
                if (displayLineCoroutine != null)
                {
                    StopCoroutine(displayLineCoroutine);
                }
                dialogueText.text = currentStory.currentText;
                dialogueText2.text = currentStory.currentText;
                canContinueToNextLine = true;
                //continueIcon.SetActive(true);
            }
            else
            {
                ContinueStory();
            }
        }
    }
   
 
    public void EnterDialogueMode(TextAsset inkJSON)
    {

        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);
        ContinueStory();
    }

    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);
        textEnd = true;
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";
        dialogueText2.text = "";
    }

    private IEnumerator DisplayLine(string line)
    {
        //empty the curent dialogue text
        dialogueText.text = "";
        dialogueText2.text = "";

        //Hide the continue button
        //continueIcon.SetActive(false);
        canContinueToNextLine = false;

        bool isAddingRichTextTag = false;
        if (scrollingText)
        {
            //display each letter one at a time
            foreach (char letter in line.ToCharArray())
            {
               
                //check for rich text taf
                if (letter == '<' || isAddingRichTextTag)
                {
                    isAddingRichTextTag = true;
                    dialogueText.text += letter;
                    dialogueText2.text += letter;
                    if (letter == '>')
                    {
                        isAddingRichTextTag = false;
                    }
                }
                //no rich text tag display noraml letters
                else
                {
                    dialogueText.text += letter;
                    dialogueText2.text += letter;
                    yield return new WaitForSeconds(typingSpeed);
                }
            }
            //continueIcon.SetActive(true);
            canContinueToNextLine = true;
        }
        else
        {
            dialogueText.text = currentStory.currentText;
            dialogueText2.text = currentStory.currentText;
            canContinueToNextLine = true;
            //continueIcon.SetActive(true);
        }
        
    }
    private void ContinueStory()
    {
        if (currentStory.canContinue)
        {
            if (displayLineCoroutine != null)
            {
                StopCoroutine(displayLineCoroutine);
            }
            displayLineCoroutine = StartCoroutine(DisplayLine(currentStory.Continue()));
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }

    }
}
