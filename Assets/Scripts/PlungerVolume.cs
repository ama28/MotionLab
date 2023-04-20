using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlungerVolume : MonoBehaviour
{
    public float volume;
    public float topVol;
    public float midVol;
    public float botVol;
    public TMP_Text volumeText;
    private int counter;
    [SerializeField] private int scrollSpeed = 15;
    private float lowerLimit;
    private float upperLimit;
    private float numTime;
    public GameObject topScroll;
    public GameObject midScroll;
    public GameObject botScroll;
    // Start is called before the first frame update
    void Start()
    {
        /* volume = 20f;
        counter = 0;
        lowerLimit = 20;
        upperLimit = 200;
        topVol = 0;
        midVol = 2;
        botVol = 0;
        volumeText.text = volume.ToString(); */
        volumeText.text = "Welcome to MotionLab. Begin by grabbing the micropipette";
    }

    // Update is called once per frame
    void Update()
    {
        /* if (Input.GetKey(KeyCode.RightArrow)){
            if (!(volume == upperLimit && counter == 0)){
                if (counter < scrollSpeed) {
                    counter++;
                }
                if (counter == scrollSpeed) {
                    if (volume < upperLimit) {
                        counter = 0;
                        volume = volume + 1;
                    }
                }
            }
        }
        if (Input.GetKey(KeyCode.LeftArrow)){
            if (!(volume == lowerLimit && counter == 0)) {
                if (volume == upperLimit) {
                    volume = volume - 1;
                    counter = scrollSpeed;
                }
                else {
                    if (counter > 0) {
                        counter--;
                    }
                    if (counter == 0) {
                        if (volume > lowerLimit) {
                            volume = volume - 1;
                            counter = scrollSpeed;
                        }
                    }
                }
                
            }
        }
        topVol = (float)(((int)(volume))/100);
        midVol = (float)((((int)(volume))/10)%10);
        botVol = volume%10;
        if (midVol == 9f && botVol == 9f) {
            numTime = (topVol/10) + (((float)counter)/(scrollSpeed*10));
        }
        else {
            numTime = (topVol/10);
        }
        topScroll.GetComponent<Animator>().SetFloat("NumTime", numTime);
        if (botVol == 9f) {
            numTime = (midVol/10) + (((float)counter)/(scrollSpeed*10));
        }
        else {
            numTime = (midVol/10);
        }
        midScroll.GetComponent<Animator>().SetFloat("NumTime", numTime);
        numTime = (botVol/10) + (((float)counter)/(scrollSpeed*10))-0.03f;
        botScroll.GetComponent<Animator>().SetFloat("NumTime", numTime);
        volumeText.text = volume.ToString(); */
    }
}
