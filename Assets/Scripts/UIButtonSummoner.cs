using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIButtonSummoner : MonoBehaviour
{
    protected Animator[] children;
    public bool uiOut = false;
    // Start is called before the first frame update
    void Start()
    {
        children = GetComponentsInChildren<Animator>();
        for (int i = 0; i < children.Length; i++) {
            children[i].SetBool("Out", uiOut);     
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)){
            uiOut = !uiOut;
            for (int i = 0; i < children.Length; i++) {
                children[i].SetBool("Out", uiOut);     
            }
        }
    }
}
