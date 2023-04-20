using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerTubeBox : MonoBehaviour
{
    private HandSlider slider;
    public GameManager manager;
    public TMP_Text uiText;

    void Start()
    {
        slider = FindObjectOfType<HandSlider>();
        manager = FindObjectOfType<GameManager>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipette") && manager.step == 16)
        {
            slider.sliderMove = true;
            slider.startingY = slider.leftHand.transform.position.y;
            slider.mySlider.GetComponent<CanvasGroup>().alpha = 1;
            manager.step++;
            uiText.text = "Now prepare to draw up liquid by pushing the plunger to the first stop.";
        }
    }

    void OnTriggerExit(Collider other)
    {
            
    }
}
