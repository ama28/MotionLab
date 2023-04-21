using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TriggerDialogue : MonoBehaviour
{
    //interaction trigger serilized fields
    [Header("Ink JSON")]
    [SerializeField] private TextAsset inkJSON;
    [SerializeField] private AudioSource voiceOver;
    [SerializeField] private TextAsset[] tasks;
    public int currentTask;
    [SerializeField] private Animator animator;
    private DialogueManager dialogueManager;
    private bool textTriggered;
    public GameManager manager;
    private Dictionary<int, int> stepToText = new Dictionary<int, int>();
    private float counter;
    [SerializeField] private float timeTillNextStep = 5f;
    private void Start()
    {
        textTriggered = false;
        currentTask = 0;
        dialogueManager = GameObject.Find("DialogueManager").GetComponent<DialogueManager>();
        manager = FindObjectOfType<GameManager>();
        stepToText.Add(0, 0);
        stepToText.Add(2, 1);
        for (int i = 4; i < 7; i++) {
            stepToText.Add(i, i-2);
        }
        for (int i = 8; i < 11; i++) {
            stepToText.Add(i, i-3);
        }
        for (int i = 13; i < 16; i++) {
            stepToText.Add(i, i-5);
        }
        for (int i = 18; i < 21; i++) {
            stepToText.Add(i, i-7);
        }
        for (int i = 22; i < 25; i++) {
            stepToText.Add(i, i-8);
        }
        stepToText.Add(26, 17);
        textTriggered = false;
        counter = 0;
    }
    private void Update()
    {
        /* if (Input.GetKeyDown("space"))
        {
            textTriggered = true;
            
           //inkJSON = Resources.Load("Resources/Instructions/Text/"+tasks[currentTask]) as TextAsset;
            DialogueManager.GetInstance().EnterDialogueMode(tasks[currentTask]);
            //voiceOver.clip = Resources.Load("Resources/Instructions/Audio/Tutorial.mp3") as AudioClip;
            voiceOver.clip = Resources.Load("Instructions/Audio/" + tasks[currentTask].name) as AudioClip;
            print(tasks[currentTask].name);
            //voiceOver.Play();
            animator.SetBool("Open", true);
            animator.SetBool("Close", false);
            currentTask++;
        } */
        if (stepToText.ContainsKey(manager.step) && !textTriggered) {
            currentTask = stepToText[manager.step];
            textTriggered = true;
            //inkJSON = Resources.Load("Resources/Instructions/Text/"+tasks[currentTask]) as TextAsset;
            DialogueManager.GetInstance().EnterDialogueMode(tasks[currentTask]);
            //voiceOver.clip = Resources.Load("Resources/Instructions/Audio/Tutorial.mp3") as AudioClip;
            //voiceOver.clip = Resources.Load("Instructions/Audio/" + tasks[currentTask].name) as AudioClip;
            print(tasks[currentTask].name);
            //voiceOver.Play();
            animator.SetBool("Open", true);
            animator.SetBool("Close", false);
        }
        if (textTriggered)
        {
            //StartCoroutine(CloseText());
            if (counter >= timeTillNextStep){
                counter = 0;
                textTriggered = false;
                manager.step++;
                animator.SetBool("Open", false);
                animator.SetBool("Close", true);
                Debug.Log(manager.step);
            }
            else {
                counter += Time.deltaTime;
            }
            
        
        }
    }
    IEnumerator CloseText()
    {
        yield return new WaitForSeconds(2f);
        print("close");
        animator.SetBool("Open", false);
        animator.SetBool("Close", true);
        textTriggered = false;
        manager.step++;

    }
               
}