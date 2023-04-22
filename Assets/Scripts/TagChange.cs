using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class TagChange : MonoBehaviour
{
    public GameObject currentTaskOn;
    public GameObject nextTaskOn;
    public GameObject nextTaskOff;
    public GameObject currentTaskOff;
    public Sprite image;
    public GameManager manager;
    //public Animator animtor;
    // Start is called before the first frame update
    void Start()
    {
        manager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        print("manager task" + manager.step);
        if (manager.step == 14)
        {
            print("task 17 tag change");
            currentTaskOn.SetActive(false);
            currentTaskOff.SetActive(true);
            nextTaskOff.SetActive(false);
            nextTaskOn.SetActive(true);
           // animtor.SetBool("NextNow", true);
        }
    }
}
