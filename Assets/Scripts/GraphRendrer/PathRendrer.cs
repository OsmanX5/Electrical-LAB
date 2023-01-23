using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathRendrer : MonoBehaviour
{
    public List<Point> points = new List<Point>();
    public LineRenderer lr;
    private void Start()
    {
        lr = GetComponent<LineRenderer>();
    }
    void FixedUpdate()
    {
        Vector3[] positions = PointsConverter.ToPositions(points);
        if (points.Count > 0)
        {
            LineRendrerOperator.PutPointsInLine(lr, positions);
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
