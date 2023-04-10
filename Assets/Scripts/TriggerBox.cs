using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerBox : MonoBehaviour
{
    private HandSlider slider;

    void Start()
    {
        slider = FindObjectOfType<HandSlider>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Pipette"))
        {
            slider.sliderMove = true;
            slider.startingY = slider.leftHand.transform.position.y;
            slider.mySlider.GetComponent<CanvasGroup>().alpha = 1;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Pipette"))
            slider.sliderMove = false;
    }
}
