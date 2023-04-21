using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIButtonSummoner : MonoBehaviour
{
    protected Animator[] children;
    public bool uiOut = false;
    public float leftHandRotation = 0;
    // Start is called before the first frame update
    void Start()
    {
        //0.6-1
        leftHandRotation = transform.parent.transform.rotation.z;
        children = GetComponentsInChildren<Animator>();
        for (int i = 0; i < children.Length; i++) {
            children[i].SetBool("Out", uiOut);     
        }
    }

    // Update is called once per frame
    void Update()
    {
        leftHandRotation = transform.parent.transform.rotation.z;
        //Debug.Log(transform.parent.transform.rotation.z);
        if (leftHandRotation >= 0.6 && leftHandRotation <= 1){
            if (uiOut) return;
            uiOut = true;
            for (int i = 0; i < children.Length; i++) {
                children[i].SetBool("Out", true);     
            }
        } 
        else {
            if (!uiOut) return;
            uiOut = false;
            for (int i = 0; i < children.Length; i++) {
                children[i].SetBool("Out", false);     
            }
        }
    }

    public void ResetGame() {
        if (uiOut) {
            GameObject.FindWithTag("Pipette").transform.position = new Vector3(0.021f, 0.412f, 0.068f);
        }
    }
}
