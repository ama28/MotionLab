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
    public GameObject microDesc;
    public GameObject leapDesc;
    public GameObject pipetteDesc;
    private int counter;
    public float hold;


    void Start(){
        trackerCanvas.SetActive(false);
        line.SetActive(false);
        step = 0;
        callNext();
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
        
        if (step != 11 && step != 12)
        {
            trackerCanvas.SetActive(false);
            line.SetActive(false);
        }
      
    }
    public void callNext()
    {
        switch (step)
        {
            case 1:
                print("task" + step);

                StartCoroutine(countTaskHold(hold, microDesc));
                break;
            case 3:
                print("task" + step);
                StartCoroutine(countTaskHold(hold, leapDesc));
                break;
            case 7:
                print("task" + step);
                StartCoroutine(countTaskHold(hold, pipetteDesc));
                break;
            default:
                print("N/A for task "+ step);
                break;
        }

    }
    private IEnumerator countTaskHold(float hold, GameObject visuals)
    {
        print("start holdd" + step);
        visuals.SetActive(true);
        yield return new WaitForSeconds(5);
        print("end holdd");
        visuals.SetActive(false);
        step++;
        callNext();
    }
}
