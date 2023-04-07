using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lr_testing : MonoBehaviour
{
    [SerializeField] private Transform[] points;
    [SerializeField] private LineBetweenObjects line;
    // Start is called before the first frame update
    private void Start()
    {
        line.SetUpLine(points); 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
