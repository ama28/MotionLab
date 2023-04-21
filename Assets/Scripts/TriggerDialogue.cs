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
    private int counter;
    private int currentStep;
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
        currentStep = 0;
        checkNextStep();
        print(manager.step);
    }
    
    private void Update()
    {
       if(manager.step> currentStep)
        {
            checkNextStep();
            currentStep = manager.step;
        }
    }
    public void checkNextStep()
    {
        if (stepToText.ContainsKey(manager.step))
        {
            currentTask = stepToText[manager.step];
            textTriggered = true;
            DialogueManager.GetInstance().EnterDialogueMode(tasks[currentTask]);
            voiceOver.clip = Resources.Load("Instructions/Audio/" + tasks[currentTask].name) as AudioClip;
            print(tasks[currentTask].name);
            voiceOver.Play();
            animator.SetBool("Open", true);
            animator.SetBool("Close", false);
            StartCoroutine(CloseText());

        }
    }
    IEnumerator CloseText()
    {
        print("strting text hold" + stepToText);
        yield return new WaitForSeconds(5);
        print("step increase");
        manager.step++;
        manager.callNext();
        textTriggered = false;
        print("close");
        animator.SetBool("Open", false);
        animator.SetBool("Close", true);
    }
               
}