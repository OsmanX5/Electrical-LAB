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
    public static void SetWireStright(LineRenderer lr, Vector3[] points)
    {
        Vector3[] allPoints = StreadLinesBetweenPoints(points);
        SetWire(lr, allPoints);
    }
    public static void SetWireStright(LineRenderer lr, Transform[] points)
    {
        Vector3[] allPoints = new Vector3[points.Length];
        for(int i = 0; i < points.Length-1; i++)
        {
            allPoints[i] = points[i].position;
        }
        SetWireStright(lr, allPoints);
    }
    public static void SetWireStright(LineRenderer lr,Vector3 startPoint, Vector3 endPoint)
    {
        List<Vector3> points = StreadLinesBetween(startPoint, endPoint);
        lr.positionCount = points.Count;
        for (int i = 0; i < points.Count; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }

    public static void SetWire(LineRenderer lr, Vector3[] points)
    {
        lr.positionCount = points.Length;
        for (int i = 0; i < points.Length; i++)
        {
            lr.SetPosition(i, points[i]);
        }
    }

    public static void AddPointToLine(LineRenderer lr, Vector3 point)
    {
        lr.positionCount++;
        lr.SetPosition(lr.positionCount - 2, point);
        lr.SetPosition(lr.positionCount - 1, point);
    }
    static Vector3[] StreadLinesBetweenPoints(Vector3[] points)
    {
        List<Vector3> path = new List<Vector3>();
        path.Add(points[0]);
        for (int i = 0; i < points.Length - 1; i++)
        {
            Vector3 start = points[i];
            Vector3 end = points[i + 1];
            Vector3 mid = new Vector3(end.x, start.y, start.z);
            path.Add(mid);
        }
        path.Add(points[points.Length-1]);
        return path.ToArray();
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
