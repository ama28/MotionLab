using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HandSlider : MonoBehaviour
{
    public Slider mySlider;
    public Slider volSlider;
    public float startingY;
    public bool sliderMove;
    public float startingX;
    public bool volMove;
    public Image Fill;
    public Image volFill;
    public Image Background;
    public Color MaxHealthColor = Color.green;
    public Color MinHealthColor = Color.red;
    public TMP_Text plungerText;
    public GameObject leftHand;
    public int volume;
    public float topVol;
    public float midVol;
    public float botVol;
    public TMP_Text volumeText;
    private float numTime;
    public GameObject topScroll;
    public GameObject midScroll;
    public GameObject botScroll;
    public int counter;
    public int goal;
    // Start is called before the first frame update
    void Start()
    {
        mySlider.value = 1;
        volSlider.value = 1;
        volMove = false;
        sliderMove = false;
        Fill.color = Color.Lerp(MinHealthColor, MaxHealthColor, 1);
        plungerText.text = "";
        mySlider.GetComponent<CanvasGroup>().alpha = 0;
        volSlider.GetComponent<CanvasGroup>().alpha = 0;
        volume = 20;
        topVol = 0;
        midVol = 2;
        botVol = 0;
        volumeText.text = volume.ToString();
        counter = 0;
        goal = 36;
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

        if (Input.GetKeyDown(KeyCode.V)){
            volMove = !volMove;
            if (volMove) {
                startingX = leftHand.transform.position.x;
                volSlider.GetComponent<CanvasGroup>().alpha = 1;
            }
        }
        if (volMove) {
            float volDisplacement = (leftHand.transform.position.x - startingX)/0.4f;
            //Debug.Log(startingY);
            //Debug.Log(transform.parent.transform.position.y);
            float tempDisplacement = 1 - volDisplacement;
            //Debug.Log(volDisplacement);
            volSlider.value = tempDisplacement;
            volDisplacement = 1 - volSlider.value;
            //mySlider.value = 1 - sliderDisplacement + 0.15;
            //Debug.Log(mySlider.value);
            volume = 20 + (int)(volDisplacement * 30);
            if (volume == goal) {
                if (counter == 100) {
                    Debug.Log("Correct!");
                    volMove= !volMove;
                    volSlider.value = 1;
                    volSlider.GetComponent<CanvasGroup>().alpha = 0;
                    volume = 20;
                    topVol = 0;
                    midVol = 2;
                    botVol = 0;
                    volumeText.text = volume.ToString();
                    counter = 0;
                }
                else {
                    counter++;
                }
            }
            else {
                counter = 0;
            }
            
            float dec = (float)((((int)((volDisplacement * 30) * 100))%100))/100;
            topVol = (float)(volume/100);
            midVol = (float)((volume/10)%10);
            botVol = (float)(volume%10);
            if (midVol == 9f && botVol == 9f) {
                numTime = (topVol/10) + (dec/10);
            }
            else {
                numTime = (topVol/10);
            }
            topScroll.GetComponent<Animator>().SetFloat("NumTime", numTime);
            if (botVol == 9f) {
                numTime = (midVol/10) + (dec/10);
            }
            else {
                numTime = (midVol/10);
            }
            midScroll.GetComponent<Animator>().SetFloat("NumTime", numTime);
            numTime = (botVol/10) + (dec/10);
            botScroll.GetComponent<Animator>().SetFloat("NumTime", numTime);
            //Debug.Log(volume);
            volumeText.text = volume.ToString();
        }
        else {
            volSlider.value = 1;
            volSlider.GetComponent<CanvasGroup>().alpha = 0;
            volume = 20;
            topVol = 0;
            midVol = 2;
            botVol = 0;
            volumeText.text = volume.ToString();
            counter = 0;
        }
        
        
    }
}
