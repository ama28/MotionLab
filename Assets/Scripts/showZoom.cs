using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;
using TMPro;

public class showZoom : MonoBehaviour
{
    private InteractionBehaviour controller;
    public GameManager manager;
    public TMP_Text uiText;
    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<InteractionBehaviour>();
        manager = FindObjectOfType<GameManager>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if(controller.isGrasped && manager.step == 10) {
            manager.step = 11;
            uiText.text = "You've grabbed the pipette. Now set the volume to 36";
        }
    }
}
