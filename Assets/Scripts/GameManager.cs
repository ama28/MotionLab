using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject trackerCanvas;
    public GameObject line;
    private bool canvasShowing;
    public int step;
    private HandSlider slider;

    void Start(){
        trackerCanvas.SetActive(false);
        line.SetActive(false);
        step = 0;
        slider = FindObjectOfType<HandSlider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        /* if (Input.GetKeyDown(KeyCode.T)) {
             canvasShowing = !canvasShowing;
             trackerCanvas.SetActive(canvasShowing);
             line.SetActive(canvasShowing);
         } */
         if (step == 1) {
            slider.volMove = true;
            slider.startingX = slider.leftHand.transform.position.x;
            slider.volSlider.GetComponent<CanvasGroup>().alpha = 1;
            trackerCanvas.SetActive(true);
            line.SetActive(true);
            step++;
         }
         if (step > 2) {
            trackerCanvas.SetActive(false);
            line.SetActive(false);
         }
    }
}
