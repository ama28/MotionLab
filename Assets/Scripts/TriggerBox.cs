using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TriggerBox : MonoBehaviour
{
    private HandSlider slider;
    public GameManager manager;
    public TMP_Text uiText;
    public GameObject leftHand;

    void Start()
    {
        slider = FindObjectOfType<HandSlider>();
        manager = FindObjectOfType<GameManager>();
    }

    void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Pipette") && manager.step == 22)
        {
            if(leftHand.transform.position.y > 0.5){
                slider.sliderMove = true;
                slider.startingY = slider.leftHand.transform.position.y;
                slider.mySlider.GetComponent<CanvasGroup>().alpha = 1;
                manager.step++;
                uiText.text = "Release the liquid by pushing to the second stop";
            }
        }
    }

    void OnTriggerExit(Collider other)
    {

            
    }
}
