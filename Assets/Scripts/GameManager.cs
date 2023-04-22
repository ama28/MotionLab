using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Leap.Unity.Interaction;

public class GameManager : MonoBehaviour
{
    public GameObject trackerCanvas;
    public GameObject line;
    public GameObject microDesc;
    public GameObject leapDesc;
    public GameObject pipetteDesc;
    public GameObject pipette;
    public Slider progress;
    private bool canvasShowing;
    public int step;
    private HandSlider slider;
    [SerializeField] private float timeTillNextStep = 2f;
    private InteractionBehaviour controller;
    private float counter;
    [SerializeField] private AudioSource voiceOver;
    private bool microliterTriggered;
    private bool leapTriggered;

    void Start(){
        trackerCanvas.SetActive(false);
        line.SetActive(false);
        microDesc.SetActive(false);
        leapDesc.SetActive(false);
        pipetteDesc.SetActive(false);
        step = 10;
        slider = FindObjectOfType<HandSlider>();
        controller = pipette.GetComponent<InteractionBehaviour>();
        progress.value = 1;
        microliterTriggered = false;
        leapTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        progress.value = ((float)step)/25f;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (Input.GetKeyDown("space"))
        {
            step++;
            Debug.Log(step);
        }

        /* if (Input.GetKeyDown(KeyCode.T)) {
             canvasShowing = !canvasShowing;
             trackerCanvas.SetActive(canvasShowing);
             line.SetActive(canvasShowing);
         } */
         if (controller.isGrasped && step == 11) {
            slider.volMove = true;
            slider.startingX = slider.leftHand.transform.position.x;
            slider.volSlider.GetComponent<CanvasGroup>().alpha = 1;
            trackerCanvas.SetActive(true);
            line.SetActive(true);
            step++;
         }
         if (step != 11 && step != 12) {
            //trackerCanvas.SetActive(false);
            //line.SetActive(false);
         }
         if (step == 1) {
            microDesc.SetActive(true);
            if(!microliterTriggered){
                microliterTriggered = true;
                voiceOver.clip = Resources.Load("Instructions/Audio/microliter") as AudioClip;
                voiceOver.Play();
            }
            if (!voiceOver.isPlaying) {
                if (counter >= timeTillNextStep){
                    counter = 0;
                    step++;
                    microDesc.SetActive(false);
                }
                else {
                    counter += Time.deltaTime;
                }
            }
            
         }
         else if (step == 3) {
            leapDesc.SetActive(true);
            if(!leapTriggered){
                leapTriggered = true;
                voiceOver.clip = Resources.Load("Instructions/Audio/leap") as AudioClip;
                voiceOver.Play();
            }
            if (!voiceOver.isPlaying) {
                if (counter >= timeTillNextStep){
                    counter = 0;
                    step++;
                    leapDesc.SetActive(false);
                }
                else {
                    counter += Time.deltaTime;
                }
            }
            
         }
        else if (step == 7) {
            pipetteDesc.SetActive(true);
            if (counter >= timeTillNextStep){
                counter = 0;
                step++;
                pipetteDesc.SetActive(false);
            }
            else {
                    counter += Time.deltaTime;
            }
        }
    }
}
