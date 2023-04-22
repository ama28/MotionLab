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
    private float counter;
    private float firstStopCounter;
    private float secondStopCounter;
    public int goal;
    public float timeAtGoal = 3f;
    public GameManager manager;
    public Image loadingBar;
    public GameObject circleBar;
    public bool firstClick;
    public bool secondClick;

    public GameObject liquidTube;
    public GameObject liquidDrop;
    public GameObject liquidPipette;
    public float baseval;
    public float basevalz;

    public GameObject plungerImage;
    private float OldSliderVal;
    [SerializeField] private AudioSource voiceOver;
    // Start is called before the first frame update
    void Start()
    {
        baseval = plungerImage.transform.position.y;
        basevalz = plungerImage.transform.position.z;
        mySlider.value = 1;
        OldSliderVal = mySlider.value;
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
        counter = 0;
        firstStopCounter = 0;
        secondStopCounter = 0;
        goal = 36;
        manager = FindObjectOfType<GameManager>();
        circleBar.SetActive(false);
        firstClick = false;
        secondClick = false;
    }

    // Update is called once per frame
    void Update()
    {
        print("values " + baseval + mySlider.value);
        print("values2 " + baseval );
        print("values3 " + mySlider.value);
        plungerImage.transform.position = new Vector3(plungerImage.transform.position.x, baseval + (mySlider.value/40), basevalz + (mySlider.value / 40));

        if (mySlider.value == 1 && manager.step == 21) {
            manager.step++;
            mySlider.GetComponent<CanvasGroup>().alpha = 0;
            liquidTube.SetActive(false);
            liquidPipette.SetActive(true);
            volumeText.text = "You've drawn up the liquid. Now bring the pipette over the paper to release the liquid";
        }
        if (mySlider.value < 0.7 && mySlider.value >= 0.55) {
            secondStopCounter = 0;
            if (manager.step == 17){
                circleBar.SetActive(true);
                if (firstStopCounter >= timeAtGoal) {
                    manager.step++;
                    circleBar.SetActive(false);
                    volumeText.text = "You've pushed to the first stop. You're ready to draw up liquid. Tap the pipette to the tube box and bring the plunger up";
                }
                else {
                    firstStopCounter += Time.deltaTime;
                }
                loadingBar.fillAmount = firstStopCounter/timeAtGoal;
            }
            else {
                firstStopCounter = 0;
                circleBar.SetActive(false);
            }
            plungerText.text = "First Stop Reached";
        }
        else if (mySlider.value >= 0 && mySlider.value < 0.2) {
            firstStopCounter = 0;
            if (manager.step == 25){
                circleBar.SetActive(true);
                if (secondStopCounter >= timeAtGoal) {
                    manager.step++;
                    circleBar.SetActive(false);
                    mySlider.GetComponent<CanvasGroup>().alpha = 0;
                    liquidPipette.SetActive(false);
                    liquidDrop.SetActive(true);
                    volumeText.text = "You've successfully released the liquid";
                }
                else {
                    secondStopCounter += Time.deltaTime;
                }
                loadingBar.fillAmount = secondStopCounter/timeAtGoal;
            }
            else {
                secondStopCounter = 0;
                circleBar.SetActive(false);
            }
            plungerText.text = "Second Stop Reached";
        }
        else {
            secondStopCounter = 0;
            firstStopCounter = 0;
            plungerText.text = "";
            circleBar.SetActive(false);
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
                circleBar.SetActive(true);
                if (counter >= timeAtGoal) {
                    Debug.Log(manager.step);
                    Debug.Log("Correct!");
                    manager.step++;
                    circleBar.SetActive(false);
                    volMove= !volMove;
                    volSlider.value = 1;
                    volSlider.GetComponent<CanvasGroup>().alpha = 0;
                    volume = 20;
                    topVol = 0;
                    midVol = 2;
                    botVol = 0;
                    counter = 0;
                    volumeText.text = "You've set the correct volume. Now bring the pipette over the tube box.";
                }
                else {
                    counter += Time.deltaTime;
                }
                loadingBar.fillAmount = counter/timeAtGoal;
            }
            else {
                circleBar.SetActive(false);
                counter = 0;
            }
            
            float dec = (float)((((int)((volDisplacement * 0) * 100))%100))/100;
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
        }
        else {
            volSlider.value = 1;
            volSlider.GetComponent<CanvasGroup>().alpha = 0;
            volume = 20;
            topVol = 0;
            midVol = 2;
            botVol = 0;
            counter = 0;
        }

    }
}
