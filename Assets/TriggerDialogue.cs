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

    private void Start()
    {

    }
    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            //inkJSON = Resources.Load("Resources/Instructions/Text/Tutorial") as TextAsset;
            DialogueManager.GetInstance().EnterDialogueMode(inkJSON);
            //voiceOver.clip = Resources.Load("Resources/Instructions/Audio/Tutorial.mp3") as AudioClip;
            voiceOver.Play();
        }
    }
               
}