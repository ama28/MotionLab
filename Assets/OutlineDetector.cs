using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Leap.Unity.Interaction;

public class OutlineDetector : MonoBehaviour
{
    private InteractionBehaviour controller;
    private AnchorableBehaviour anchor;
    private Outline outline;

    private float curDistance;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<InteractionBehaviour>();
        anchor = gameObject.GetComponent<AnchorableBehaviour>();
        outline = gameObject.GetComponent<Outline>();
    }

    // Update is called once per frame
    void Update()
    {
        curDistance = controller.closestHoveringControllerDistance;
        if (curDistance > 9999 || anchor.isAttached)
        {
            outline.enabled = false;
        }
        else
        {
            outline.enabled = true;
        }
    }
}
