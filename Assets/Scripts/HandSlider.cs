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
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;
    public TMP_Text plungerText;
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
        if (mySlider.value > 0.45 && mySlider.value < 0.6) {
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
                startingY = transform.parent.transform.position.y;
                mySlider.GetComponent<CanvasGroup>().alpha = 1;
            }
        }
        if (sliderMove) {
            float sliderDisplacement = (startingY - transform.parent.transform.position.y)/0.15f;
            //Debug.Log(startingY);
            //Debug.Log(transform.parent.transform.position.y);
            mySlider.value = 1 - sliderDisplacement;
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
