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
}
