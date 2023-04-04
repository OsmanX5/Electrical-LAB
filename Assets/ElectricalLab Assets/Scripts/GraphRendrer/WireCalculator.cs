using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class LineRendrerOperator 
{    
    public static void PutPointsInLine(LineRenderer lr, Vector3[] points)
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
        lr.SetPosition(lr.positionCount - 1, point);
    }
    public static Vector3[] GetLineRendrerPoints(LineRenderer lr)
    {
        Vector3[] points = new Vector3[lr.positionCount];
        for (int i = 0; i < lr.positionCount; i++)
        {
            points[i] = lr.GetPosition(i);
        }
        return points;
    }
    
}
