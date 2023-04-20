using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerBox : MonoBehaviour
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
        if (other.CompareTag("Pipette") && (manager.step >= 23 && manager.step <= 25))
        {
            slider.sliderMove = true;
            slider.startingY = slider.leftHand.transform.position.y;
            slider.mySlider.GetComponent<CanvasGroup>().alpha = 1;
            uiText.text = "Release the liquid by pushing to the second stop";
        }
    }

    void OnTriggerExit(Collider other)
    {

            
    }
}
