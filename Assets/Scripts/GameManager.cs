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
        step = 0;
        slider = FindObjectOfType<HandSlider>();
        controller = pipette.GetComponent<InteractionBehaviour>();
        progress.value = 1;
        microliterTriggered = false;
        leapTriggered = false;
        counter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        progress.value = ((float)step)/25f;
        if (Input.GetKeyDown(KeyCode.R))
        {
            GameObject.FindWithTag("Pipette").transform.position = new Vector3(0.021f, 0.412f, 0.068f);
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
         if (controller.isGrasped && step >= 4){
            trackerCanvas.SetActive(true);
            line.SetActive(true);
         }
         if (controller.isGrasped && step == 7) {
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
            leapDesc.SetActive(true);
            if (!voiceOver.isPlaying) {
                if (counter >= 0){
                    counter = 0;
                    leapDesc.SetActive(false);
                }
                else {
                    counter += Time.deltaTime;
                }
            }
            
         }
         else if (step == 2) {
            microDesc.SetActive(true);
            if (!voiceOver.isPlaying) {
                if (counter >= 0){
                    counter = 0;
                    microDesc.SetActive(false);
                }
                else {
                    counter += Time.deltaTime;
                }
            }
            
         }
    }
}
