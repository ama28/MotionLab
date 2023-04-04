using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushTriggerBox : MonoBehaviour
{
    private BoxCollider col; 
    private bool isHoldingPipette = false; 
    public bool temp = false; 

    // Start is called before the first frame update
    void Start()
    {
        col = GetComponent<BoxCollider>();
    }

    public void GrabbedPipette()
    {
        isHoldingPipette = true;
    }

    public void LetGoPipette()
    {
        isHoldingPipette = false;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Pipette") && isHoldingPipette)
        {
            temp = true;
            // enable the meter here
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Pipette") && isHoldingPipette)
        {
            temp = false;
            // disable the meter here
        }
    }
}
