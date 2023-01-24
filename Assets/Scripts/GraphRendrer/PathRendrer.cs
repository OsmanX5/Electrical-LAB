using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRendrer : MonoBehaviour
{
    List<Point> points = new List<Point>();
    LineRenderer LR;
    private void Start()
    {
        LR = GetComponent<LineRenderer>();
    }
    void FixedUpdate()
    {
        UpdateLR();
    }
    public void UpdateLR()
    {
        Vector3[] positions = PointsConverter.ToPositions(points);
        if (points.Count > 0)
        {
            LineRendrerOperator.PutPointsInLine(LR, positions);
        }
    }
    public void SetPoints(List<Point> points)
    {
        this.points = points;
    }
    public void Remove(Point a)
    {
        Debug.Log("deleting from rendrer" + a.ID);
        points.Remove(a);
    }
}
