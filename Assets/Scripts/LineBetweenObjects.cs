using UnityEngine;
using UnityEngine.UI;

public class LineBetweenObjects : MonoBehaviour
{
    private LineRenderer lr;
    [SerializeField] private Transform[] points;
    private Vector3 pos1;
    private Vector3 pos2;

    private void Awake()
    {
        lr = GetComponent<LineRenderer>();
        lr.positionCount = points.Length;
        pos1 = new Vector3(points[0].position.x + 1, points[0].position.y, points[0].position.z);
        pos2 = new Vector3(points[1].position.x - 1, points[1].position.y, points[1].position.z);
    }
    public void SetUpLine(Transform[] points)
    {
        
        lr.positionCount = points.Length;
        this.points = points;
    }

    private void Update()
    {
        for(int i = 0; i < points.Length; i++)
        {
            pos1 = new Vector3(points[0].position.x + 0.03f, points[0].position.y, points[0].position.z);
            pos2 = new Vector3(points[1].position.x - 0.03f, points[1].position.y, points[1].position.z);
            if (i == 0)
            {
                lr.SetPosition(i, pos1);
            }
            if(i == 1)
            {
                lr.SetPosition(i, pos2);
            }
            Vector3 pos = new Vector3(points[i].position.x + 10, points[i].position.y, points[i].position.y);
            
        }
    }
}

