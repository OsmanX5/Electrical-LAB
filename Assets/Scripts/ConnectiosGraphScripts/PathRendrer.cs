using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRendrer : MonoBehaviour
{
    public List<Point> points = new List<Point>();
    void Update()
    {
        if (points.Count > 0)
        {
            LineRenderer lr = GetComponent<LineRenderer>();
            lr.positionCount = points.Count;
            for (int i = 0; i < points.Count; i++)
            {
                lr.SetPosition(i, points[i].transform.position);
            }
        }
    }
}
