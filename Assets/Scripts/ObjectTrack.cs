using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrack : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private Transform Subject;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Subject)
        {

            Vector3 pos = new Vector3( Subject.position.x, Subject.position.y, transform.position.z);
            
            if (transform.position.y < pos.y -0.01f || transform.position.y > pos.y + 0.01f || transform.position.x < pos.x - 0.01f || transform.position.x > pos.x + 0.01f)
            {
                transform.position = pos;
            }
            /*Vector3 pos = cam.WorldToScreenPoint(Subject.position);

            if (transform.position.y < pos.y - 0.01f || transform.position.y > pos.y + 0.01f)
            {
                transform.position = pos;
            }*/
        }
    }
}
