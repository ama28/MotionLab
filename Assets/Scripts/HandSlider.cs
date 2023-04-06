using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandSlider : MonoBehaviour
{
    public Slider mySlider;
    public float startingY;
    public bool sliderMove;
    public Image Fill;
    public Image Background;
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;
    public TMP_Text plungerText;
    public GameObject leftHand;
    private bool bounce;
    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = 1;
        sliderMove = false;
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, 1);
        plungerText.text = "";
        mySlider.GetComponent<CanvasGroup>().alpha = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (mySlider.value < 0.7 && mySlider.value >= 0.55) {
            plungerText.text = "First Stop Reached";
        }
        else if (mySlider.value >= 0 && mySlider.value < 0.2) {
            plungerText.text = "Second Stop Reached";
        }
        else {
            plungerText.text = "";
        }
        if (Input.GetKeyDown(KeyCode.P)){
            sliderMove = !sliderMove;
            if (sliderMove) {
                startingY = leftHand.transform.position.y;
                mySlider.GetComponent<CanvasGroup>().alpha = 1;
            }
        }
        if (sliderMove) {
            float sliderDisplacement = (startingY - leftHand.transform.position.y)/0.15f;
            //Debug.Log(startingY);
            //Debug.Log(transform.parent.transform.position.y);
            float tempDisplacement = 1 - sliderDisplacement;
            if (tempDisplacement >= 0.7f) {
                mySlider.value = tempDisplacement;
            }
            else if (tempDisplacement > 0.25f && tempDisplacement < 0.7f) {
                mySlider.value = 0.7f - (0.7f - tempDisplacement) * 0.1f;
            }
            else if (tempDisplacement <= 0.25f) {
                mySlider.value = 0.65f - (0.65f - (tempDisplacement + 0.4f)) * 0.5f;
            }
            
            //mySlider.value = 1 - sliderDisplacement + 0.15;
            Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, mySlider.value);
            //Debug.Log(mySlider.value);
        }
        else {
            mySlider.value = 1;
            Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, 1);
            plungerText.text = "";
            mySlider.GetComponent<CanvasGroup>().alpha = 0;
        }
        
        
    }
}
