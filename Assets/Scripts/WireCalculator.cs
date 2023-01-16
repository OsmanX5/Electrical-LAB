using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class WireCalculator : MonoBehaviour
{
    public static GameObject LRPrefab;
    public Transform StartPoint;
    public Transform EndPoint;

    public static void SetWire(LineRenderer lr, Transform[] points)
    {
        List<Vector3> allPoints = new List<Vector3>();
        for(int i = 0; i < points.Length-1; i++)
        {
            allPoints.AddRange(StreadLinesBetween(points[i].position, points[i+1].position));
        }
        lr.positionCount = allPoints.Count;
        for (int i = 0; i < allPoints.Count; i++)
        {
            lr.SetPosition(i, allPoints[i]);
        }
    }
    public static void SetWire(LineRenderer lr,Vector3 startPoint, Vector3 endPoint)
    {
        List<Vector3> points = StreadLinesBetween(startPoint, endPoint);
        lr.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }

    static List<Vector3> StreadLinesBetween(Vector3 start, Vector3 end)
    {
        List<Vector3> path = new List<Vector3>();
        path.Add(start);
        Vector3 mid = new Vector3( end.x, start.y , start.z );
        path.Add(mid);
        path.Add(end);
        return path;
    }
}
